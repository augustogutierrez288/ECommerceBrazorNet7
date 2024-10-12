using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ECommerceBrazorNet7.Services.Contract;
using ECommerceBrazorNet7.DTO;

namespace ECommerceBrazorNet7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleServices)
        {
            _saleService = saleServices;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] SaleDTO model)
        {
            var response = new ResponseDTO<SaleDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _saleService.Register(model);
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
