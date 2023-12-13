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
       
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Policy = "AdministratorAndConsultant")]
        public async Task<IActionResult> GetAll(int parameter=0) 
        {
            return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.UserRepository.GetAllUsers(parameter));
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "AdministratorAndConsultant")]
        public async Task<IActionResult> GetById([FromRoute] int id, int parameter=0) 
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
                    return ResponseFactory.CreateErrorResponse(404, "El usuario no pudo ser encontrado.");
                }
            }
            catch (Exception ex)
            {

                return ResponseFactory.CreateErrorResponse(500, "Ocurrió un error inesperado.");
            }
        }

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
                    return ResponseFactory.CreateSuccessResponse(200, "La operación de registro fue exitosa.");
                }
                return ResponseFactory.CreateErrorResponse(400, "La operación de registro fracaso.");
            }
            catch (Exception ex)
            {

                return ResponseFactory.CreateErrorResponse(500, "Ocurrió un error inesperado.");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Update([FromRoute] int id, UserRegisterDTO userRegisterDTO, int parameter=0) 
        {
            try
            {
                var result = await _unitOfWork.UserRepository.UpdateUser(userRegisterDTO, id, parameter);

                if (result != false) 
                {
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, "La operación de actualización fue exitosa.");
                }
                return ResponseFactory.CreateErrorResponse(400, "La operación de actualización fracaso.");
            }
            catch (Exception ex)
            {

                return ResponseFactory.CreateErrorResponse(500, "Ocurrió un error inesperado.");
            }
        }    

        [HttpDelete("{id}")]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Delete([FromRoute] int id,int parameter = 0) 
        {
            try
            {
                var result = await _unitOfWork.UserRepository.DeleteUserById(id, parameter);
                if (result != false)
                {
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, "La operación de eliminación fue exitosa.");
                }
                return ResponseFactory.CreateErrorResponse(400, "La operación de eliminación fracaso.");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "Ocurrió un error inesperado.");
            }
        }
    }
}
