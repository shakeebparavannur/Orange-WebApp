using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orange.Services.ProductAPI.Models.Dto;
using Orange.Services.ProductAPI.Repository;

namespace Orange.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    [ApiController]

    public class ProductAPIController : ControllerBase
    {
        private ResponseDto response;
        private readonly IProductRepository productRepository;

        public ProductAPIController(IProductRepository repository)
        {
            productRepository = repository;
            response = new ResponseDto();
        }
        [HttpGet]
        public async Task <IActionResult> Get () 
        {
            try
            {
                IEnumerable<ProductDto> products = await productRepository.GetProducts();
                response.Result = products;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false; 
                response.ErrorMessages = new List<string> { ex.Message };
                return BadRequest(response);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                ProductDto product = await productRepository.GetProductById(id);
                response.IsSuccess = true;
                response.Result = product;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return BadRequest(response);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto dto)
        {
            try
            {
                ProductDto product = await productRepository.CreateUpdateProduct(dto);
                response.Result = product;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return BadRequest(response);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isDelete = await productRepository.DeleteProduct(id);
                response.Result = isDelete;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return BadRequest(response);
            }
        }

    }
}
