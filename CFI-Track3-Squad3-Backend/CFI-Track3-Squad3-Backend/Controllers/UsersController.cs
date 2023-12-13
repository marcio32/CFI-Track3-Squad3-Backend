using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Infrectuture;
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UsersController> _logger;
       
        public UsersController(IUnitOfWork unitOfWork, ILogger<UsersController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        //obtener listado de usuarios metodo HTTP GET
        //parametros:
        //-parameter: se utiliza para el filtrado de usuarios
        //    -parametro 0: para obtener el filtro de usuarios no eliminados
        //    -parametro 1: para recuperar a todos los usuarios
        //-pageSize: se utiliza para indicar cuantos elementos mostrar por paginas
        //-pageToShow: se utiliza para indicar en que pagina se encuentra navegando
        //devoluciones:
        //-devuelve el listado de usuarios con el codigo 200
        //-devuelve un mensaje de error con el codigo 500, error de servidor


        [HttpGet]
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
                _logger.LogError(ex, "A ocurrido un error inesperado");
                return ResponseFactory.CreateErrorResponse(500, "A ocurrido un error inesperado");

            }

        }
        //obtener un usuario por ID metodo HTTP GET
        ////parametros:
        ////-id: se utiliza para obtener el usuarios mediante esa identidad
        //-parameter: se utiliza para filtrar por usuario eliminado o no eliminado        
        ////    -parametro 0: para obtener el filtro de usuarios no eliminados
        ////    -parametro 1: para recuperar a todos los usuarios
        ////devoluciones:
        ////-devuelve el usuario que coincide con el ID con el codigo 200
        //-devuelve mediante un codigo 404, el mensaje de usuario no encontrado
        ////-devuelve un mensaje de error con el codigo 500, error de servidor


        [HttpGet("{id}")]
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

                return ResponseFactory.CreateErrorResponse(500, "Ocurrió un error inesperado.");
            }
        //registro de usuario en la base de datos metodo HTTP POST
        //////parametros:
        //////-"userRegisterDTO": se utiliza el modelo para completar la informacion del usuario
        //////devoluciones:
        //////-devuelve el mensaje de operacion exitosa mediante el codigo 201
        ////-devuelve mediante un codigo 400, el mensaje de operacion cancelada
        //////-devuelve un mensaje de error con el codigo 500, error de servidor

        [HttpPost]
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
        actualizar un usuario por ID metodo HTTP PUT
        ////parametros:
        ////-id: se utiliza para obtener el usuarios mediante esa identidad
        ////-"userRegisterDTO": se utiliza el modelo para reemplazar la informacion del usuario
        //-parameter: se utiliza para indicar el tipo de actualizacion a realizar        
        ////    -parametro 0: para reemplazar datos antiguos
        ////    -parametro 1: para recuperar datos temporales eliminados
        //////devoluciones:
        //////-devuelve el mensaje de actualizacion exitosa mediante el codigo 200
        ////-devuelve mediante un codigo 400, el mensaje de operacion cancelada
        //////-devuelve un mensaje de error con el codigo 500, error de servidor
        [HttpPut("{id}")]
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

                return ResponseFactory.CreateErrorResponse(500, "Ocurrió un error inesperado.");
            }
        }    
        eliminar un usuario de forma temporal o permanente por ID metodo HTTP DELETE
        ////parametros:
        ////-id: se utiliza para obtener el usuarios mediante esa identidad
        //-parameter: se utiliza para indicar el tipo de eliminacion a realizar        
        ////    -parametro 0: para eliminar de forma temporal
        ////    -parametro 1: para eliminar de forma permanente
        //////devoluciones:
        //////-devuelve el mensaje de eliminado correctamente mediante el codigo 200
        ////-devuelve mediante un codigo 400, el mensaje de operacion cancelada
        //////-devuelve un mensaje de error con el codigo 500, error de servidor
        [HttpDelete("{id}")]
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
