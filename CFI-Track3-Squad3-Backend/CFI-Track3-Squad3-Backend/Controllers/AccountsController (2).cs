using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Infrectuture;
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("GetAllRole")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.RoleRepository.GetAllRole());
        }

        [HttpGet]
        [Route("GetRoleId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _unitOfWork.RoleRepository.GetRoleId(id);
            if (result != null)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.RoleRepository.GetRoleId(id));
            }
            return ResponseFactory.CreateErrorResponse(404, "Rol no encontrado.");
        }
        
        [HttpPost]
        [Route("InsertRole")]
        public async Task<IActionResult> Insert(int id, RoleDTO roleDTO)
        {
            var result = await _unitOfWork.RoleRepository.InsertRole(roleDTO);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Rol ingresado correctamente.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error al ingresar rol.");
        }

        [HttpPut]
        [Route("UpdataRole")]
        public async Task<IActionResult> Updata(int id, RoleDTO roleDTO) 
        {
            var result = await _unitOfWork.RoleRepository.UpdataRole(roleDTO, id);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Rol actualizado correctamente.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error al acualizar rol.");
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.RoleRepository.DeleteRole(id);
            if (result) 
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Rol eliminado correctamente.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error al eliminar rol");
        }
    }    
}
