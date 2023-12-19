using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Infrectuture;
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController2 : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController2> _logger;


        public UserController2(IUnitOfWork unitOfWork, ILogger<UserController2> logger) 
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

       
        [HttpGet("GetAllUser")]
        [Authorize(Policy = "AdministratorAndConsultant")]
        public async Task<IActionResult> GetAll() 
        {
            return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.UserRepository2.GetAllUsers2());
        }

        [HttpGet("GetUser/{id}")]
        [Authorize(Policy = "AdministratorAndConsultant")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _unitOfWork.UserRepository2.GetUser2ById(id);
            if (result != null)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.UserRepository2.GetUser2ById(id));
            }
            return ResponseFactory.CreateErrorResponse(404, "Usurio no encontrado.");
        }

        [HttpPost("RegisterUser")]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Insert(int id, UserRegisterDTO userRegisterDTO)
        {
            var result = await _unitOfWork.UserRepository2.RegisterUser2(userRegisterDTO);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Usuario ingresado correctamente.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error al ingresar Usuario.");
        }

        [HttpPut("UpdateUser/{id}")]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Update(int id, UserRegisterDTO userRegisterDTO)
        {
            var result = await _unitOfWork.UserRepository2.UpdateUser2(id, userRegisterDTO);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Usuario actualizado correctamente.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error al acualizar Usuario.");
        }

        [HttpDelete("DeleteUser/{id}")]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Delete(int id) 
        {
            var result = await _unitOfWork.UserRepository2.DeleteUser2(id);
            if (result) 
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Usurio eliminado correctamente.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error al elimianr usuario.");
        }
    }
}
