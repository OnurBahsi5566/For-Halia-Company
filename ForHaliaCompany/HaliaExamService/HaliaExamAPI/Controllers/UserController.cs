using HaliaExamAPI.DAL.Abstract;
using HaliaExamAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HaliaExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userRepository;

        public UserController(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("CreateUser")]
        public IActionResult Create(User user)
        {
            if (_userRepository.CheckEmail(user.email) != null)
            {
                return Ok(_userRepository.CheckEmail(user.email));
            }

            if (_userRepository.CheckPhone(user.phone) != null)
            {
                return Ok(_userRepository.CheckPhone(user.phone));
            }

            if (!_userRepository.IsValidPassword(user.password))
            {
                return Ok("Invalid Password.");
            }

            _userRepository.Insert(user);
            return Ok("Success");

        }

        [HttpPost("LoginUser")]
        public IActionResult Login(Login user)
        {
            var userAvailable = _userRepository.LoginControl(user);

            if (userAvailable != null)
            {
                return Ok("Success");
            }

            return Ok("User not found.");
        }

        [HttpGet("GetUsersInfo")]
        public IActionResult GetUsersInfo()
        {
            var userInfos = _userRepository.GetUsersInfo();
            return Ok(userInfos);
        }

        [HttpGet("GetSessionInfo")]
        public IActionResult GetSessionInfo(string email, string password)
        {
            var user = _userRepository.GetSessionInfo(email, password);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }
    }
}