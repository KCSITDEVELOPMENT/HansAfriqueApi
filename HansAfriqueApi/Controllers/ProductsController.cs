using AutoMapper;
using HansAfriqueApi.Data;
using HansAfriqueApi.Dto;
using HansAfriqueApi.Entities;
using HansAfriqueApi.Helpers;
using HansAfriqueApi.Interface;
using HansAfriqueApi.Specifications;
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
        private readonly IGenericRepository<Part> _partsRepo;
        private readonly IGenericRepository<Brand> _brandsRepo;
        private readonly IGenericRepository<Vehicle> _vehiclesRepo;
        private readonly IGenericRepository<PartCategory> _partscategoryRepo;
        private readonly IGenericRepository<Supplier> _suppliersRepo;
        private readonly IGenericRepository<PartNumber> _partnumbeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Part> partsRepo, IGenericRepository<Brand> brandsRepo, 
            IGenericRepository<Vehicle> vehiclesRepo, IGenericRepository<PartCategory> partscategoryRepo,
            IGenericRepository<Supplier> suppliersRepo, IGenericRepository<PartNumber> partnumbeRepo, IMapper mapper)
        {
            _partsRepo = partsRepo;
            _brandsRepo = brandsRepo;
            _vehiclesRepo = vehiclesRepo;
            _partscategoryRepo = partscategoryRepo;
            _suppliersRepo = suppliersRepo;
            _partnumbeRepo = partnumbeRepo;
           _mapper = mapper;

        }

        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<Pagination<IReadOnlyList<ProductDto>>>> GetProducts(
            [FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductSpecifications(productParams);

            var countSpec = new ProductFiltersCountSpecification(productParams);

            var totalItems = await _partsRepo.CountAsync(spec);

            var products = await _partsRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Part>, IReadOnlyList<ProductDto>>(products);

            return Ok(new Pagination<ProductDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductSpecifications(id);

            var product = await _partsRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Part,ProductDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetProductBrand()
        {
            return Ok(await _brandsRepo.ListAllAsync());
        }

        [HttpGet("vehicles")]
        public async Task<ActionResult<IReadOnlyList<Vehicle>>> GetProductVehicles()
        {
           return Ok (await _vehiclesRepo.ListAllAsync());
        }


        [HttpGet("supplier")]
        public async Task<ActionResult<IReadOnlyList<Vehicle>>> GetSupplier()
        {
            return Ok(await _suppliersRepo.ListAllAsync());
        }

        [HttpGet("category")]
        public async Task<ActionResult<IReadOnlyList<PartCategory>>> GetCategory()
        {
            return Ok(await _partscategoryRepo.ListAllAsync());
        }

        [HttpGet("partnamber")]
        public async Task<ActionResult<IReadOnlyList<PartCategory>>> GetPartnumber()
        {
            return Ok(await _partnumbeRepo.ListAllAsync());
        }

    }

}
