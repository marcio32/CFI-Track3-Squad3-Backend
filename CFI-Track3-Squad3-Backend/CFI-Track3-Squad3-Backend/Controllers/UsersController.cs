using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Helper;
using CFI_Track3_Squad3_Backend.Infrectuture; // Parece haber un error tipográfico en 'Infrectuture'.
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Controllers
{
    /// <summary>
    /// Controlador para la gestión de usuarios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UsersController> _logger;

        /// <summary>
        /// Constructor que recibe instancias necesarias para la gestión de usuarios.
        /// </summary>
        public UsersController(IUnitOfWork unitOfWork, ILogger<UsersController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint para obtener un listado paginado de usuarios.
        /// </summary>
        [HttpGet("GetAllUsers")]
        [Authorize(Policy = "AdministratorAndConsultant")]
        public async Task<IActionResult> GetAll(int parameter = 0, int pageSize = 10, int pageToShow = 1)
        {
            try
            {
                var usersDTO = await _unitOfWork.UserRepository.GetAllUsers(parameter);
                if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateUsers = PaginateHelper.Paginate(usersDTO, pageToShow, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(200, paginateUsers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error inesperado.");
                return ResponseFactory.CreateErrorResponse(500, "Ha ocurrido un error inesperado.");
            }
        }

        /// <summary>
        /// Endpoint para obtener un usuario por su ID.
        /// </summary>
        [HttpGet("GetUserId/{id}")]
        [Authorize(Policy = "AdministratorAndConsultant")]
        public async Task<IActionResult> GetById([FromRoute] int id, int parameter = 0)
        {
            try
            {
                var userDTO = await _unitOfWork.UserRepository.GetUserById(id, parameter);

                if (userDTO != null)
                {
                    return ResponseFactory.CreateSuccessResponse(200, userDTO);
                }
                else
                {
                    _logger.LogError("El usuario no fue encontrado");
                    return ResponseFactory.CreateErrorResponse(404, "El usuario no fue encontrado");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A ocurrido un error inesperado");
                return ResponseFactory.CreateErrorResponse(500, "A ocurrido un error inesperado");
            }
        }

        /// <summary>
        /// Endpoint para registrar un nuevo usuario.
        /// </summary>
        [HttpPost("RegisterUser")]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var result = await _unitOfWork.UserRepository.InsertUser(userRegisterDTO);
                if (result != false)
                {
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(201, "La operacion de registro fue exitosa");
                }
                _logger.LogError("La operacion fue cancelada");
                return ResponseFactory.CreateErrorResponse(400, "La operacion fue cancelada");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A ocurrido un error inesperado");
                return ResponseFactory.CreateErrorResponse(500, "A ocurrido un error inesperado");
            }
        }

        /// <summary>
        /// Endpoint para actualizar un usuario por su ID.
        /// </summary>
        [HttpPut("UpdateUser/{id}")]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Update([FromRoute] int id, UserRegisterDTO userRegisterDTO, int parameter = 0)
        {
            try
            {
                var result = await _unitOfWork.UserRepository.UpdateUser(userRegisterDTO, id, parameter);

                if (result != false)
                {
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, "La actualizacion fue exitosa");
                }
                _logger.LogError("La operacion fue cancelada");
                return ResponseFactory.CreateErrorResponse(400, "La operacion fue cancelada");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A ocurrido un error inesperado");
                return ResponseFactory.CreateErrorResponse(500, "A ocurrido un error inesperado");
            }
        }

        /// <summary>
        /// Endpoint para eliminar un usuario de forma temporal o permanente por su ID.
        /// </summary>
        [HttpDelete("DeleteUser/{id}")]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Delete([FromRoute] int id, int parameter = 0)
        {
            try
            {
                var result = await _unitOfWork.UserRepository.DeleteUserById(id, parameter);
                if (result != false)
                {
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, "Se a eliminado correctamente");
                }

                _logger.LogError("La operacion fue cancelada");
                return ResponseFactory.CreateErrorResponse(400, "La operacion fue cancelada");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A ocurrido un error inesperado");
                return ResponseFactory.CreateErrorResponse(500, "A ocurrido un error inesperado");
            }
        }
    }
}
