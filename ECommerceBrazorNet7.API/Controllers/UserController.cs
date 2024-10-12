using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ECommerceBrazorNet7.Services.Contract;
using ECommerceBrazorNet7.DTO;

namespace ECommerceBrazorNet7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userServices)
        {
            _userService = userServices;
        }

        [HttpGet("List/{role:alpha}/{found?}")]
        public async Task<IActionResult> List(string role, string found = "NA")
        {
            var response = new ResponseDTO<List<UserDTO>>();

            try
            {
                if (found == "NA") found = string.Empty;

                response.IsCorrect = true;
                response.Result = await _userService.ListUser(role, found);
            }
            catch (Exception ex) 
            { 
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("GetUser/{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var response = new ResponseDTO<UserDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _userService.GetUser(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CrateUser([FromBody]UserDTO model)
        {
            var response = new ResponseDTO<UserDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _userService.CreateUser(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromBody]LoginDTO model)
        {
            var response = new ResponseDTO<SessionDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _userService.Authorization(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody]UserDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _userService.UpdateUser(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("DeleteUser/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _userService.DeleteUser(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
