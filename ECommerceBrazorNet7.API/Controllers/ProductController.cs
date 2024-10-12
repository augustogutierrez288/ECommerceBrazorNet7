using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ECommerceBrazorNet7.Services.Contract;
using ECommerceBrazorNet7.DTO;
using ECommerceBrazorNet7.Services.Implementation;

namespace ECommerceBrazorNet7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productServices)
        {
            _productService = productServices;
        }

        [HttpGet("List/{found:alpha?}")]
        public async Task<IActionResult> List(string found = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();

            try
            {
                if (found == "NA") found = string.Empty;

                response.IsCorrect = true;
                response.Result = await _productService.ListProduct(found);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Catalog/{category?}/{found?}")]
        public async Task<IActionResult> ProductCatalog(string category ,string found = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();

            try
            {
                if (category.ToLower() == "total") category = string.Empty;
                if (found == "NA") found = string.Empty;

                response.IsCorrect = true;
                response.Result = await _productService.ProductCatalog(category,found);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("GetProduct/{id:int?}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _productService.GetProduct(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO model)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _productService.CreateProduct(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _productService.UpdateProduct(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("DeleteProduct/{id:int?}")]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _productService.DeleteProduct(id);
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
