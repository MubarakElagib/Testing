using System;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Backend.Dtos;
using Demo.Backend.Interfaces;
using Demo.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }


        [HttpPost(Name = "AddProduct")]
        public async Task<IActionResult> AddProduct(ProductForCreationDto productForCreationDto)
        {
            var product = _mapper.Map<Product>(productForCreationDto);
            _repo.Add(product);
            if (await _repo.SaveAll())
                return Ok();

            throw new Exception("Creating the Product failed on save");
        }


        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
                return BadRequest();

            var productFromRepo = await _repo.GetProduct(id);

            if (productFromRepo == null)
                return NotFound();
                
            _repo.Delete(productFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Error deleting the product");
        }


        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repo.GetProducts();
            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null)
                return BadRequest();

            var product = await _repo.GetProduct(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}