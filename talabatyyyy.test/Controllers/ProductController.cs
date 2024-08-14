using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using talabatyyyy.Core.Entities;
using talabatyyyy.Core.ParamOfQuery;
using talabatyyyy.Core.Repository;
using talabatyyyy.Core.Specification;
using talabatyyyy.test.Dtos;
using talabatyyyy.test.Errors;

namespace talabatyyyy.test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> brandRepo;
        private readonly IGenericRepository<ProductType> typeRepo;
        private readonly IMapper mapper;

        public ProductController(IGenericRepository<Product> productRepo ,
            IGenericRepository<ProductBrand> brandRepo,
            IGenericRepository<ProductType> typeRepo,
            IMapper mapper)
        {
            this.productRepo = productRepo;
            this.brandRepo = brandRepo;
            this.typeRepo = typeRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts([FromQuery] ProductParamQuery productParamQuery )
        {
            var spec = new ProductSpecification(productParamQuery);
            var products= await productRepo.GetProductsWithSpecAsync(spec);
            var productsMapper = mapper.Map<IEnumerable<ProductToReturnDto>>(products);
            return Ok(productsMapper);
        }
        [HttpGet("id")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductSpecification(id);
            var product = await productRepo.GetProductWithSpecAsync(spec);
            if (product==null)
            {
                return NotFound(new ApiErrorResponse(404));
            }
            var productMapper = mapper.Map<ProductToReturnDto>(product);
            return Ok(productMapper);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrands()
        {
            var brands = await brandRepo.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetTypes()
        {
            var types = await typeRepo.GetAllAsync();
            return Ok(types);
        }
    }
}
