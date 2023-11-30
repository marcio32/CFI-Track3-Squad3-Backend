using CFI_Track3_Squad3_Backend.DTOs;
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

        [Route("GetAllUsers")]
        [HttpGet]
        public ActionResult GetAll() 
        {
            return Ok("Users");
        }

        [HttpGet]
        [Route("/api/producto/{id}")]
        public ActionResult GetById(int id) 
        {
            return Ok(id + "User");
        }

        [Route("AddUser")]
        [HttpPost]
        public ActionResult AddUser(UserLoginDTO userLoginDTO) 
        {
            return Ok(userLoginDTO);
        }

        [Route("UpdataUser")]
        [HttpPut]
        public ActionResult UpdataUser(UserLoginDTO userLoginDTO) 
        {
            return Ok(userLoginDTO);
        }

        [Route("DeleteUser")]
        [HttpDelete]
        public ActionResult DeleteUser(int id) 
        {
            return Ok("User Delete");
        }
    }
}
