using apparelshop.Contracts;
using apparelshop.Dtos;
using apparelshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace apparelshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _productsRepository;

        public ProductsController(IProducts productsRepository)
        {
            _productsRepository = productsRepository;
        }

        /// <summary>
        /// 查詢所有商品資料
        /// </summary>
        /// <returns>所有商品的資料</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productsRepository.GetAllProducts();
            return Ok(new
            {
                Success = true,
                Message = "成功取得所有商品資料",
                Data = products
            });
        }

        /// <summary>
        /// 查詢指定 ID 的商品資料
        /// </summary>
        /// <param name="id">商品的唯一識別碼</param>
        /// <returns>指定商品的資料</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productsRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的商品資料"
                });
            }

            return Ok(new
            {
                Success = true,
                Message = "成功取得指定商品資料",
                Data = product
            });
        }

        /// <summary>
        /// 新增商品資料
        /// </summary>
        /// <param name="product">新增的商品資料</param>
        /// <returns>新增後的商品資料</returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductsForCreationDto product)
        {
            var createdProduct = await _productsRepository.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct }, new
            {
                Success = true,
                Message = "成功新增商品資料",
                Data = createdProduct
            });
        }

        /// <summary>
        /// 更新指定 ID 的商品資料
        /// </summary>
        /// <param name="id">商品的唯一識別碼</param>
        /// <param name="product">更新的商品資料</param>
        /// <returns>更新結果</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductsForUpdateDto product)
        {
            var existingProduct = await _productsRepository.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的商品資料"
                });
            }

            await _productsRepository.UpdateProduct(id, product);
            return Ok(new
            {
                Success = true,
                Message = "成功更新商品資料"
            });
        }

        /// <summary>
        /// 刪除指定 ID 的商品資料
        /// </summary>
        /// <param name="id">商品的唯一識別碼</param>
        /// <returns>刪除結果</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _productsRepository.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的商品資料"
                });
            }

            await _productsRepository.DeleteProduct(id);
            return Ok(new
            {
                Success = true,
                Message = "成功刪除商品資料"
            });
        }
    }
}
