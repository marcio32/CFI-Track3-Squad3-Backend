using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Infrectuture;
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("GetAllAccounts")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.AccountsRepository.GetAllAccount());
        }

        [HttpGet]
        [Route("GetAccountId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _unitOfWork.AccountsRepository.GetAccountId(id);
            if (result != null)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.AccountsRepository.GetAccountId(id));
            }
            return ResponseFactory.CreateErrorResponse(404, "Cuenta no encontrada.");
        }
        
        [HttpPost]
        [Route("InsertAccount")]
        public async Task<IActionResult> Insert(int id, AccountsDTO accountsDTO)
        {
            var result = await _unitOfWork.AccountsRepository.InsertAccount(accountsDTO);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Cuenta ingresada correctamente.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error al ingresar cuenta.");
        }

        [HttpPut]
        [Route("UpdataAccount")]
        public async Task<IActionResult> Updata(int id, AccountsDTO accountsDTO) 
        {
            var result = await _unitOfWork.AccountsRepository.UpdataAccount(accountsDTO, id);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Cuenta actualizada correctamente.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error al acualizar cuenta.");
        }

        [HttpDelete]
        [Route("DeleteAccount")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.AccountsRepository.DeleteAccount(id);
            if (result) 
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Cuenta eliminada correctamente.");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error al eliminar cuenta");
        }
    }    
}
