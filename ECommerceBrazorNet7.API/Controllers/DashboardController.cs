using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ECommerceBrazorNet7.Services.Contract;
using ECommerceBrazorNet7.DTO;
using ECommerceBrazorNet7.Services.Implementation;

namespace ECommerceBrazorNet7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("Resume")]
        public IActionResult Resume()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = _dashboardService.Resume();
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
