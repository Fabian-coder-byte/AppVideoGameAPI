using APIJustEatProject.Configuration;
using APIJustEatProject.Credenizali;
using AppVideoGameAPI.Data;
using AppVideoGameAPI.Models;
using AppVideoGameAPI.Utilities;
using AppVideoGameAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<DataUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        public AccountController(ApplicationDbContext context,
            IMapper mapper, ILogger<AccountController> logger,
            UserManager<DataUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JwtBearerTokenSettings> jwtTokenOptions) : base(context, mapper)
        {
            _logger = logger;
            _userManager=userManager;
            _roleManager=roleManager;
            _jwtBearerTokenSettings = jwtTokenOptions.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy hh:mm")} AccountController - Login - {credentials?.UserName}");
                DataUser user;
                if (!ModelState.IsValid || credentials == null || (user = await ValidateUser(credentials)) == null)
                    return BadRequest("Login fallito");
                string token = await GenerateToken(user);
                DataUser UtenteLoggato = await _userManager.FindByEmailAsync(user.Email!) ?? throw new ArgumentException(Constants.UtenteNontrovato);
                UtenteLoggato.UltimoAccesso = DateTime.Now;
                await _userManager.UpdateAsync(UtenteLoggato);
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now.ToString("dd/MM/yyyy hh:mm")} AccountController - Login - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] DatiRegistrazioneVM credentials)
        {
            try
            {
               

                if (!credentials.Password!.Equals(credentials.PasswordConfermata))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Le Password non Corrispondono");
                }
                DataUser? userFoundViaEmail = await _userManager.FindByEmailAsync(credentials.Email!);
                if (userFoundViaEmail != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Utente Non Trovato");

                }
                Guid idAspNetUser = Guid.NewGuid();
                DataUser user = new()
                {
                    Id = idAspNetUser.ToString(),
                    UserName = credentials.Email,
                    Email = credentials.Email,
                    EmailConfirmed = true,
                    Nome = credentials.Nome,
                    Cognome = credentials.Cognome,
                    IndirizzoUtente=credentials.IndirizzoUtente
                };
                await CreateUserRole(user, credentials.Password, "Customer");
                return Ok(JsonConvert.SerializeObject(user, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now.ToString("dd/MM/yyyy hh:mm")} AccountController - Login - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("GetUser")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy hh:mm")} AccountController");
                var username = User.Identity.Name;
                var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now.ToString("dd/MM/yyyy hh:mm")} AccountController - Login - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        #region [ PRIVATE METHODS ]
        private async Task<DataUser> ValidateUser(LoginCredentials credentials)
        {
            PasswordVerificationResult result = PasswordVerificationResult.Failed;
            DataUser? user = await _userManager.FindByNameAsync(credentials.UserName);
            if (user != null && user.EmailConfirmed)
                result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash!, credentials.Password);
            return result == PasswordVerificationResult.Failed ? null : user;
        }

        private async Task<string> GenerateToken(DataUser user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_jwtBearerTokenSettings.SecretKey);
            // Ottieni i ruoli dell'utente in modo asincrono
            var roles = await _userManager.GetRolesAsync(user);
            // Crea i claim inclusi i ruoli
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            // Aggiungi ogni ruolo come claim
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(_jwtBearerTokenSettings.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtBearerTokenSettings.Audience,
                Issuer = _jwtBearerTokenSettings.Issuer
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private async Task CreateUserRole(DataUser user, string Password, string Ruolo)
        {
            try
            {
                //Crezione Utente
                IdentityResult createUserResult = await _userManager.CreateAsync(user, Password);
                await ErrorCreateUser(createUserResult, user);
                //Aggiunta ruolo Utente
                IdentityResult addUserToRoleResult = await _userManager.AddToRoleAsync(user, Ruolo);
                await ErrorAddRoleUser(createUserResult, addUserToRoleResult, user);
            }
            catch (Exception ex)
            {
                RedirectToAction("Error", "Bene", new { errMsg = ex.Message.ToString(), innExc = ex.InnerException?.Message.ToString() });
            }
        }
        private async Task ErrorCreateUser(IdentityResult createUserResult, DataUser user)
        {
            if (!createUserResult.Succeeded)
            {
                IdentityResult deleteUserResult = await _userManager.DeleteAsync(user);
                if (!deleteUserResult.Succeeded)
                {
                    StringBuilder sb1 = new();
                    List<string> errors1 = deleteUserResult.Errors.Select(x => x.Description).ToList();
                    foreach (string s in errors1) sb1.AppendLine(s);
                    throw new BadHttpRequestException(sb1.ToString());
                }
                StringBuilder sb = new();
                List<string> errors = createUserResult.Errors.Select(x => x.Description).ToList();
                foreach (string s in errors) sb.AppendLine(s);
                throw new BadHttpRequestException(sb.ToString());
            }
        }
        private async Task ErrorAddRoleUser(IdentityResult createUserResult, IdentityResult addUserToRoleResult, DataUser user)
        {
            if (!addUserToRoleResult.Succeeded)
            {
                IdentityResult deleteUserResult = await _userManager.DeleteAsync(user);
                if (!deleteUserResult.Succeeded)
                {
                    StringBuilder sb1 = new();
                    List<string> errors1 = deleteUserResult.Errors.Select(x => x.Description).ToList();
                    foreach (string s in errors1) sb1.AppendLine(s);
                    throw new BadHttpRequestException(sb1.ToString());
                }
                StringBuilder sb = new();
                List<string> errors = createUserResult.Errors.Select(x => x.Description).ToList();
                foreach (string s in errors) sb.AppendLine(s);
                throw new BadHttpRequestException(sb.ToString());
            }
        }

        #endregion
    }
}
