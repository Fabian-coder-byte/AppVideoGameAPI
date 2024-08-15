using APIJustEatProject.Configuration;
using APIJustEatProject.Credenizali;
using AppVideoGameAPI.Data;
using AppVideoGameAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
                return Ok(token);
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

        #endregion
    }
}
