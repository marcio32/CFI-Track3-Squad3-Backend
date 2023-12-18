using AutoMapper;
using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Helper;
using CFI_Track3_Squad3_Backend.Infrectuture; // Parece haber un error tipográfico en 'Infrectuture'.
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor que recibe una instancia de IUnitOfWork para la inyección de dependencias.
        /// </summary>
        public AccountsController(IUnitOfWork unitOfWork,IMapper mapper, ILogger<UsersController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            
        }

        /// <summary>
        /// Endpoint para obtener todos los registros de cuentas.
        /// </summary>
        [Route("GetAllAccounts")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int parameter = 0, int pageSize = 10, int pageToShow = 1)
        {
            try
            {
                var accountsDTO = await _unitOfWork.AccountsRepository.GetAllAccounts(parameter);
                if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
                var paginateAccounts = PaginateHelper.Paginate(accountsDTO, pageToShow, url, pageSize);
                return ResponseFactory.CreateSuccessResponse(200, paginateAccounts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A ocurrido un error inesperado");
                return ResponseFactory.CreateErrorResponse(500, "A ocurrido un error inesperado");
            }
            
        }

        /// <summary>
        /// Endpoint para obtener un registro de cuenta por su ID.
        /// </summary>
        [HttpGet]
        [Route("GetAccountId/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, int parameter =0)
        {
            try
            {
                var accountDTO = await _unitOfWork.AccountsRepository.GetAccountById(id, parameter);
                if (accountDTO != null)
                {

                    return ResponseFactory.CreateSuccessResponse(200, accountDTO);
                }
                else
                {
                    _logger.LogError("La cuenta no fue encontrada");
                    return ResponseFactory.CreateErrorResponse(404, "Cuenta no encontrada.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A ocurrido un error inesperado");
                return ResponseFactory.CreateErrorResponse(500, "A ocurrido un error inesperado");
            }
           
        }
        
            


        /// <summary>
        /// Endpoint para insertar un nuevo registro de cuenta.
        /// </summary>
        [HttpPost]
        [Route("InsertAccount")]
        public async Task<IActionResult> Insert(int id, AccountDTO accountsDTO)
        {
            var result = await _unitOfWork.AccountsRepository.InsertAccount(accountsDTO);
            if (result != null)
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
        [Route("UpdateAccount")] // Parece haber un error tipográfico en 'UpdataAccount'.
        public async Task<IActionResult> Update([FromRoute]int id, AccountDTO accountDTO, int parameter =0)
        {
            try
            {
                var result = await _unitOfWork.AccountsRepository.UpdateAccount(accountDTO, id, parameter);
                if (result != false)
                {
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, "Cuenta actualizada correctamente.");
                }
                _logger.LogError("La operacion fue cancelada");
                return ResponseFactory.CreateErrorResponse(400, "Error al acualizar cuenta.");
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "A ocurrido un error inesperado");
                return ResponseFactory.CreateErrorResponse(500, "A ocurrido un error inesperado");
            }
        }

        /// <summary>
        /// Endpoint para eliminar un registro de cuenta por su ID.
        /// </summary>
        [HttpDelete]
        [Route("DeleteAccount")]
        public async Task<IActionResult> Delete([FromRoute]int id, int parameter =0)
        {
            try
            {
                var result = await _unitOfWork.AccountsRepository.DeleteAccountById(id, parameter);
                if (result != false)
                {
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, "Cuenta eliminada correctamente.");
                }
                _logger.LogError("La operacion fue cancelada");
                return ResponseFactory.CreateErrorResponse(400, "Error al eliminar cuenta");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A ocurrido un error inesperado");
                return ResponseFactory.CreateErrorResponse(500, "A ocurrido un error inesperado");
            }
        }
    }
}
