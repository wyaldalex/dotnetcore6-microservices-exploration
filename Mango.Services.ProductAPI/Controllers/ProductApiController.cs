using Mango.Services.ProductAPI.Models.Dtos;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductApiController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductApiController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {

                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.isSuccess = true;
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {

                ProductDto productDto = await _productRepository.GetProduct(id);
                _response.isSuccess = true;
                _response.Result = productDto;
            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto product)
        {
            try
            {

                ProductDto createdProduct = await _productRepository.CreateUpdateProduct(product);
                _response.isSuccess = true;
                _response.Result = createdProduct;
            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto product)
        {
            try
            {

                ProductDto updatedProduct = await _productRepository.CreateUpdateProduct(product);
                _response.isSuccess = true;
                _response.Result = updatedProduct;
            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {

                bool deleteResponse = await _productRepository.DeleteProduct(id);
                _response.isSuccess = true;
                _response.Result = deleteResponse;
            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.Message };
            }
            return _response;
        }

    }
}
