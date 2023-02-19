
using Core.Abtracts;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        public IProductRepository _repository { get; }
        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        { 
            var products = await _repository.GetProductsAsync();
            return Ok(products);
            
        }
        [HttpGet("{id}")]
         public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _repository.GetProductByIdAsync(id);
        }
        [HttpGet("brands")]
         public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repository.GetProductBrandsAsync());
        }
          [HttpGet("types")]
         public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repository.GetProductTypesAsync());
        }
    }
}