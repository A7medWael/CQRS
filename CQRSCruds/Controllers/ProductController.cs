using CQRSData.CQRS.Commands;
using CQRSData.CQRS.Queirs;
using CQRSData.Data.DTOS;
using CQRSData.Repos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSCruds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepos _productRepos;
        public ProductController(IProductRepos productRepos)
        {
            _productRepos = productRepos;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {


            return Ok(await _productRepos.GetAll());
        }
        [HttpGet("GetProductbyId")]
        public async Task<IActionResult> GetProductbyId(int id)
        {


            return Ok(await _productRepos.GetById(id));
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDTO product)
        {


            return Ok(await _productRepos.Insert(product));
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteProduct(int id)
        {


            return Ok(await _productRepos.Delete(id));
        }
    }
}
