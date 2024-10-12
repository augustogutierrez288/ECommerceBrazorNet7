using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ECommerceBrazorNet7.Services.Contract;
using ECommerceBrazorNet7.DTO;

namespace ECommerceBrazorNet7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("List/{found:alpha?}")]
        public async Task<IActionResult> List(string found = "NA")
        {
            var response = new ResponseDTO<List<CategoryDTO>>();

            try
            {
                if (found == "NA") found = string.Empty;

                response.IsCorrect = true;
                response.Result = await _categoryService.ListCategory(found);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("GetCategory/{id:int}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var response = new ResponseDTO<CategoryDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _categoryService.GetCategory(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO model)
        {
            var response = new ResponseDTO<CategoryDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _categoryService.CreateCategory(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateUser([FromBody] CategoryDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _categoryService.UpdateCategory(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _categoryService.DeleteCategory(id);
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
