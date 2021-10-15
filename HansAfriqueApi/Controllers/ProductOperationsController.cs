using HansAfriqueApi.Dto;
using HansAfriqueApi.Entities;
using HansAfriqueApi.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductOperationsController : ControllerBase
    {
        private readonly IProductOperationsInterface _iproductOperationsInterface;

        public ProductOperationsController(IProductOperationsInterface iproductOperationsInterface)
        {
            _iproductOperationsInterface = iproductOperationsInterface;
        }

        [HttpPost("save")]
        public async Task<ActionResult> CreatePeople(CreateProductDto productDto)
        {
            var part = new Part
            {
                Name = productDto.Name,
                PartCode = productDto.PartCode,
                Brandid = productDto.Brand,
                Vehicleid = productDto.Vehicle,
                Supplierid = productDto.Supplier,
                PictureULR = productDto.PictureULR,
                Price = productDto.Price,
                PartCategoryid = productDto.PartCategory,
                PartNumberid = productDto.PartNumber,
                VehicleModel = productDto.VehicleModel,
                id = productDto.id
            };

            await _iproductOperationsInterface.AddProduct(part);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Updateproduct(ProductUpdateDto productUpdateDto, int id)
        {

            var part = new Part
            {
                id = id,
                Name = productUpdateDto.Name,
                PartNumberid = productUpdateDto.PartNumberid,
                Brandid =  productUpdateDto.Brandid,
                Supplierid = productUpdateDto.Supplierid,
                PictureULR = productUpdateDto.PictureULR,
                PartCategoryid = productUpdateDto.PartCategoryid,
                PartCode = productUpdateDto.PartCode,
                Price = productUpdateDto.Price,
                VehicleModel = productUpdateDto.VehicleModel
            };

            await _iproductOperationsInterface.UpdateProduct(part);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePeople(int id)
        {
            await _iproductOperationsInterface.DeleteProduct(id);
            return Ok();
        }
    }
}
