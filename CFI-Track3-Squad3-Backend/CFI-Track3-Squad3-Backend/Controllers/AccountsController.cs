using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Infrectuture; // Parece haber un error tipográfico en 'Infrectuture'.
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Controllers
{
    /// <summary>
    /// Controlador para operaciones relacionadas con cuentas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController2> _logger;

        /// <summary>
        /// Constructor que recibe una instancia de IUnitOfWork para la inyección de dependencias.
        /// </summary>
        public AccountsController(IUnitOfWork unitOfWork, ILogger<UserController2> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint para obtener todos los registros de cuentas.
        /// </summary>
        [Route("GetAllAccounts")]
        [HttpGet]
        [Authorize(Policy = "AdministratorAndConsultant")]
        public async Task<IActionResult> GetAll()
        {
            return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.AccountsRepository.GetAllAccount());
        }

        /// <summary>
        /// Endpoint para obtener un registro de cuenta por su ID.
        /// </summary>
        [HttpGet]
        [Route("GetAccountId/{id}")]
        [Authorize(Policy = "AdministratorAndConsultant")]
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

        /// <summary>
        /// Endpoint para insertar un nuevo registro de cuenta.
        /// </summary>
        [HttpPost]
        [Route("InsertAccount")]
        [Authorize(Policy = "Administrator")]
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

        /// <summary>
        /// Endpoint para actualizar un registro de cuenta existente.
        /// </summary>
        [HttpPut]
        [Route("UpdataAccount")] 
        [Authorize(Policy = "Administrator")]
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

        /// <summary>
        /// Endpoint para eliminar un registro de cuenta por su ID.
        /// </summary>
        [HttpDelete]
        [Route("DeleteAccount")]
        [Authorize(Policy = "Administrator")]
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
