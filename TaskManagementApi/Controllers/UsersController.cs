using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManagementApi.Models;
using TaskManagementApi.Models.DTO;
using TaskManagementApi.Repository.IRepository;

namespace TaskManagementApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepo;
        protected ApiResponse _reponse;
        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _reponse = new();
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse>> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _userRepo.Login(model);
            if (loginResponse == null)
            {
                ApiResponse.SuccessResponse(_reponse, HttpStatusCode.BadRequest, false, "UserName or Passowrd is " +
                    "incorrect", null);
                return BadRequest(_reponse);
            }
            ApiResponse.SuccessResponse(_reponse, HttpStatusCode.OK, true, null,loginResponse);
            return Ok(_reponse);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> Register([FromBody] RegistrationRequestDTO model)
        {
            bool isUniqueUser = _userRepo.IsUniqueUser(model.UserName);
            if(!isUniqueUser)
            {
                ApiResponse.SuccessResponse(_reponse,HttpStatusCode.BadRequest,false,null,null);
                return BadRequest(_reponse);
            }
            var user=await _userRepo.Rgeister(model);
            if (user == null)
            {
                ApiResponse.SuccessResponse(_reponse, HttpStatusCode.BadRequest, false, "error during registration", null);
                return BadRequest(_reponse);
            }
            ApiResponse.SuccessResponse(_reponse, HttpStatusCode.OK, true, null,user);
            return Ok(_reponse);
        }

    }
}
