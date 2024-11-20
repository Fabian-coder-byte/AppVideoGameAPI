using APIJustEatProject.Configuration;
using APIJustEatProject.Credenizali;
using AppVideoGameAPI.Data;
using AppVideoGameAPI.Models;
using AppVideoGameAPI.Utilities;
using AppVideoGameAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data;
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
            _userManager = userManager;
            _roleManager = roleManager;
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
                return Ok(JsonConvert.SerializeObject(token, new JsonSerializerSettings()
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
        [Authorize]
        [HttpGet]
        [Route("GetUser")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                string? email = (User?.Identity?.Name) ?? throw new ArgumentNullException("Utente non trovato");
                string? ruolo = (User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value) ?? throw new ArgumentException("Wuolo non trovato");
                DataUser UtenteLOggato = await _userManager.FindByEmailAsync(email) ?? throw new ArgumentException("Errore Utente");
                DatiUtente DatiUtente = new()
                {
                    Cognome = UtenteLOggato.Cognome!,
                    Email = email,
                    Nome = UtenteLOggato.Nome!,
                    UserId = UtenteLOggato.Id,
                    Ruolo = ruolo,
                    Phone = UtenteLOggato.PhoneNumber!
                };
                AllegatoUtente? allegatoUtente = _context.AllegatiUtente.FirstOrDefault(a => a.UserId == UtenteLOggato.Id && a.TipoAllegatoId==1);
                if (allegatoUtente != null)
                    DatiUtente.CodeImage = Convert.ToBase64String(allegatoUtente.Content!);
                return Ok(JsonConvert.SerializeObject(DatiUtente, new JsonSerializerSettings()
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
        [HttpGet]
        [Route("GetAllIndirizzi")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllIndirizzi(string userId)
        {
            try
            {
                List<Models.IndirizzoResidenza> IndirizziResidenza =
                     [.. _context.IndirizzoResidenza.Where(x => x.UserId == userId)];
                List<DTO.IndirizzoResidenza> Result = [];
                foreach (Models.IndirizzoResidenza ind in IndirizziResidenza)
                {
                    DTO.IndirizzoResidenza Indir = new()
                    {
                        Id = ind.Id,
                        Indirizzo = ind.NomeIndirizzo!,
                        Citta = ind.NomeCitta!
                    };
                    Result.Add(Indir);
                }
                return Ok(JsonConvert.SerializeObject(Result, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateEditIndirizzo")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateEditIndirizzo([FromBody] IndirzzoUtenteVM DataSent)
        {
            try
            {
                if (!TryValidateModel(DataSent))
                {
                    throw new ArgumentException(Constants.BadRequest);
                }
                Models.IndirizzoResidenza IndirizzoResidenza = new()
                {
                    Id = DataSent.Id,
                    NomeCitta = DataSent.NomeCitta,
                    NomeIndirizzo = DataSent.NomeIndirizzo,
                    UserId = DataSent.UserId,

                };
                if (DataSent.Id == 0)
                {
                    _context.IndirizzoResidenza.Add(IndirizzoResidenza);
                }
                else
                {
                    _context.IndirizzoResidenza.Update(IndirizzoResidenza);
                }
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(IndirizzoResidenza, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetByIdIndirizzo")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetByIdIndirizzo(int Id)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                IndirizzoResidenza IndirizzoResidenza = _context.IndirizzoResidenza.FirstOrDefault(x => x.Id == Id)
                    ?? throw new ArgumentException(Constants.IndirizzoNotFound);
                    DTO.IndirizzoResidenza Result = new()
                    {
                        Id = IndirizzoResidenza.Id,
                        Indirizzo = IndirizzoResidenza.NomeIndirizzo!,
                        Citta = IndirizzoResidenza.NomeCitta!
                    };
                return Ok(JsonConvert.SerializeObject(Result, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("RemoveIndirizzo")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveIndirizzo(string userId, int indirizzoId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException(Constants.BadRequest);
                }
                Models.DataUser Utente = await _context.Users
                    .Include(x=>x.IndirizziResidenza)
                 .FirstOrDefaultAsync(u => u.Id == userId)
                 ?? throw new ArgumentException(Constants.BadRequest);
                IndirizzoResidenza IndirizzoResidenza = _context.IndirizzoResidenza.FirstOrDefault(x=>x.Id==indirizzoId)
                    ?? throw new ArgumentException(Constants.BadRequest);  
                Utente.IndirizziResidenza!.Remove(IndirizzoResidenza);
                _context.IndirizzoResidenza.Remove(IndirizzoResidenza);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(IndirizzoResidenza, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("EditProfile")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileVM DataSent)
        {
            try
            {
                if (!TryValidateModel(DataSent))
                {
                    throw new ArgumentException(Constants.BadRequest);
                }
                Models.DataUser Utente = await _context.Users
                  .FirstOrDefaultAsync(u => u.Id == DataSent.UserId)
                  ?? throw new ArgumentException(Constants.BadRequest);
                Utente.Nome = DataSent.Nome;
                Utente.Cognome = DataSent?.Cognome;
                Utente.PhoneNumber = DataSent?.Telefono;
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(Utente, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordVM DataSent)
        {
            try
            {
                if (!TryValidateModel(DataSent))
                {
                    throw new ArgumentException(Constants.BadRequest);
                }
                Models.DataUser Utente = await _context.Users
                  .FirstOrDefaultAsync(u => u.Id == DataSent.UserId)
                  ?? throw new ArgumentException(Constants.BadRequest);
                IdentityResult result = await _userManager.ChangePasswordAsync(Utente, DataSent.PasswordCorrente!.Trim()!, DataSent.NuovaPassword!.Trim()!);
                if (!result.Succeeded)
                {
                    throw new ArgumentException(Constants.BadRequest);
                }
                await _userManager.UpdateAsync(Utente);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(Utente, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("AddAllegato")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAllegato( UtenteAllegatoVM ObjSent)
        {
            try
            {
                if (!TryValidateModel(ObjSent)) return BadRequest();
                AllegatoUtente? FotoProfilo = _context.AllegatiUtente.FirstOrDefault(x=>x.UserId==ObjSent.UtenteId);

                Models.DataUser Utente = await _context.Users
                    .Include(u => u.AllegatiUtenti)
                    .FirstOrDefaultAsync(u => u.Id == ObjSent.UtenteId)
                    ?? throw new ArgumentException(Constants.BadRequest);
                if (FotoProfilo!=null)
                {
                    foreach(var im in Utente.AllegatiUtenti!.Where(x=>x.TipoAllegatoId==1))
                    {
                        Utente.AllegatiUtenti!.Remove(im);
                        _context.AllegatiUtente.Remove(im);
                    }
                }
                foreach (IFormFile el in ObjSent.FileCaricato)
                {
                    using BinaryReader reader = new(el.OpenReadStream());
                    Utente.AllegatiUtenti!.Add(new()
                    {
                        Content = reader.ReadBytes((int)el.Length),
                        NomeFile = el.FileName,
                        UserId = Utente.Id,
                        TipoAllegatoId=1
                    });
                }
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(ObjSent, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
        [HttpGet]
        [Route("GetImageById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetImageById(string Id)
        {
            try
            {
                AllegatoUtente AllegatoUtenteGame = _context.AllegatiUtente.FirstOrDefault(a => a.UserId == Id) ?? throw new ArgumentException(Constants.ImmagineNotFound);
                string codeImage = Convert.ToBase64String(AllegatoUtenteGame.Content!);
                return Ok(codeImage);
            }
            catch (Exception ex)
            {
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
