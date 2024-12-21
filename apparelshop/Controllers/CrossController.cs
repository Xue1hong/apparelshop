using apparelshop.Contracts;
using apparelshop.Models;
using apparelshop.Repositories;
using apparelshop.Utilities;
using Microsoft.AspNetCore.Mvc;
namespace apparelshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrossController : ControllerBase
    {
        // 記錄和追蹤應用程式的運行時行為及各種訊息，如警告、錯誤等
        private readonly ILogger<CrossController> _logger;
        // 宣告此控制器所要依賴的介面（Interface），而不是其實作
        private readonly ICross _cross;
        public CrossController(ILogger<CrossController> logger, ICross cross)
        {
            // 注入Logger 服務
            _logger = logger;
            // 注入Cross 服務
            _cross = cross;}

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
        
                // 取得所有訂單列表
            var orders = await _cross.GetAllOrders();
            return Ok(new
            {
                Success = true,
                Message = "成功取得所有訂單列表",
                Data = orders
            });
        }
        //新增訂單
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Orders order)
        {
            try
            {
                // 新增訂單
                var newOrder = await _cross.AddOrder(order);
                return Ok(new
                {
                    Success = true,
                    Message = "新增訂單成功",
                    Data = newOrder
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ProductsForCustomers/{id}")]
        public async Task<IActionResult> GetProductsByCustomersId(int id)
        {
            try
            {
                // 取得指定顧客的商品資料
                var Customers = await _cross.GetProductsByCustomersId(id);
                return Ok
                    (new
                {
                     Success = true,
                        Message = "取得指定顧客的所有商品成功",
                        Data = Customers
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("CustomersForProducts/{id}")]
        public async Task<IActionResult> GetCustomersByProductsId(int id)
        {
            try
            {
                // 取得指定顧客的商品資料
                var Products = await _cross.GetCustomersByProductsId(id);
                return Ok
                    (new
                    {
                        Success = true,
                        Message = "取得指定產品的所有客戶資料成功",
                        Data = Products
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ProductsDetailsForCustomer/{id}")]
        public async Task<IActionResult> GetProductsDetailsByCustomersId(int id)
        {
            try
            {
                // 取得指定 CustomerId 的所有產品詳細資料
                var productsDetails = await _cross.GetProductsByCustomersId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定客戶的所有產品詳細資料成功",
                    Data = productsDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("CustomersDetailsForProduct/{id}")]
        public async Task<IActionResult> GetCustomersDetailsByProductsId(int id)
        {
            try
            {
                // 取得指定 ProductId 的所有客戶詳細資料
                var customersDetails = await _cross.GetCustomersByProductsId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定產品的所有客戶詳細資料成功",
                    Data = customersDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
