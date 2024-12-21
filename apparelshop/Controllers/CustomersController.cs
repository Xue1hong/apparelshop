using apparelshop.Contracts;
using apparelshop.Dtos;
using apparelshop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apparelshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomers _customersRepository;

        public CustomersController(ICustomers customersRepository)
        {
            //_customersRepository = customersRepository;
            _customersRepository = customersRepository ?? throw new ArgumentNullException(nameof(customersRepository));

        }

        /// <summary>
        /// 查詢所有客戶資料
        /// </summary>
        /// <returns>所有客戶的資料</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customersRepository.GetAllCustomers();
            return Ok(new
            {
                Success = true,
                Message = "成功取得所有客戶資料",
                Data = customers
            });
        }

        /// <summary>
        /// 查詢指定 ID 的客戶資料
        /// </summary>
        /// <param name="id">客戶的唯一識別碼</param>
        /// <returns>指定客戶的資料</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customersRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的客戶資料"
                });
            }

            return Ok(new
            {
                Success = true,
                Message = "成功取得指定客戶資料",
                Data = customer
            });
        }

        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="customer">新增的客戶資料</param>
        /// <returns>新增後的客戶資料</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomersForCreationDto customer)
        {
            var createdCustomer = await _customersRepository.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerID}, new
            {
                Success = true,
                Message = "成功新增客戶資料",
                Data = createdCustomer
            });
        }
        /// <summary>
        /// 更新指定 ID 的客戶資料
        /// </summary>
        /// <param name="id">客戶的唯一識別碼</param>
        /// <param name="customer">更新的客戶資料</param>
        /// <returns>更新結果</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomersForUpdateDto customer)
        {
            var existingCustomer = await _customersRepository.GetCustomerById(id);
            if (existingCustomer == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的客戶資料"
                });
            }

            await _customersRepository.UpdateCustomer(id, customer);
            return Ok(new
            {
                Success = true,
                Message = "成功更新客戶資料"
            });
        }

        /// <summary>
        /// 刪除指定 ID 的客戶資料
        /// </summary>
        /// <param name="id">客戶的唯一識別碼</param>
        /// <returns>刪除結果</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var existingCustomer = await _customersRepository.GetCustomerById(id);
            if (existingCustomer == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的客戶資料"
                });
            }

            await _customersRepository.DeleteCustomer(id);
            return Ok(new
            {
                Success = true,
                Message = "成功刪除客戶資料"

            });
        }
    }
}
