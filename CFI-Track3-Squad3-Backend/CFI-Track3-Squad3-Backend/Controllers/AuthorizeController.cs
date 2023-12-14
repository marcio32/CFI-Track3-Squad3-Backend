using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Helper;
using CFI_Track3_Squad3_Backend.Infrectuture;
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthorizeController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UsersController> _logger;

        public AuthorizeController(IUnitOfWork unitOfWork, IConfiguration configuration, ILogger<UsersController> logger) 
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateDTO authenticateDTO) 
        {
            try
            {
                var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(authenticateDTO);
                if(userCredentials is null) 
                {
                    return ResponseFactory.CreateErrorResponse(401, "Las credenciales son incorrectas.");
                }
                if(userCredentials.IsDelete != false) 
                {
                    return ResponseFactory.CreateErrorResponse(500, "Usurio Eliminado.");
                }
                if(userCredentials.Role.IsDeleted != false) 
                {
                    return ResponseFactory.CreateErrorResponse(500, "Rol Eliminado.");
                }

                var token = _tokenJwtHelper.GenerateToken(userCredentials);
                var user = new UserLoginDTO()
                {
                    FirstName = userCredentials.FirstName,
                    LastName = userCredentials.LastName,
                    Email = userCredentials.Email,
                    Token = token
                };
                return ResponseFactory.CreateSuccessResponse(200, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A ocurrido un error inesperado.");
                return ResponseFactory.CreateErrorResponse(500, "A ocurrido un error inesperado.");
            }
        }
    }
}
