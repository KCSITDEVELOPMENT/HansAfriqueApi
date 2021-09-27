using HansAfriqueApi.Data;
using HansAfriqueApi.Entities;
using HansAfriqueApi.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IProduct _repo;

        public ProductsController(IProduct repo, DataContext context)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Part>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Part>>> GetProduct(int id)
        {
            var products = await _repo.GetProductByIdAsync(id);
            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetProductBrand()
        {
            return Ok(await _repo.GetProductsBrandsAsync());
        }

        [HttpGet("vehicles")]
        public async Task<ActionResult<IReadOnlyList<Vehicle>>> GetProductTypes()
        {
            return Ok(await _repo.GetVehicleAsync());
        }


        [HttpGet("supplier")]
        public async Task<ActionResult<IReadOnlyList<Vehicle>>> GetSupplier()
        {
            return Ok(await _repo.GetProductsSuppliersAsync());
        }

        [HttpGet("category")]
        public async Task<ActionResult<IReadOnlyList<PartCategory>>> GetCategory()
        {
            return Ok(await _repo.GetCategoryAsync());
        }
    }
}
