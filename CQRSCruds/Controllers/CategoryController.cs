using CQRSData.Data.Modela;
using CQRSData.Repos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSCruds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepos _categoryRepos;

        public CategoryController(ICategoryRepos categoryRepos)
        {
           _categoryRepos = categoryRepos;
        }
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
           
            return Ok( await _categoryRepos.GetAll());
        }
        [HttpGet("GetCategoryByid")]
        public async Task<IActionResult> GetCategoryByid(int id)
        {

            return Ok(await _categoryRepos.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory(Category category)
        {

            return Ok(await _categoryRepos.Insert(category));
        }
        [HttpPut]
        public async Task<IActionResult> EditCategory(int id,Category category)
        {

            return Ok(await _categoryRepos.Update(id,category));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            return Ok(await _categoryRepos.Delete(id));
        }
    }
}
