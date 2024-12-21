using Dapper;
using apparelshop.Contracts;
using apparelshop.Dtos;
using apparelshop.Models;
using apparelshop.Utilities;
using System.Data;
using System.Data.Common;

namespace apparelshop.Repositories
{
    public class CustomersRepository : ICustomers
    {
        private readonly DbContext _dbContext;

        public CustomersRepository(DbContext dbContext)
        {
            //_dbContext = dbContext;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// 查詢所有Customers資料
        /// </summary>
        /// <returns>所有Customers資料</returns>
        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            const string query = "SELECT * FROM Customers ORDER BY CustomerID";
            using (var connection = _dbContext.CreateConnection())
            {
                var customers = await connection.QueryAsync<Customers>(query);
                return customers ?? new List<Customers>();
            }
        }

        /// <summary>
        /// 查詢單一Customers資料（依指定id）
        /// </summary>
        /// <param name="id">Customers的唯一識別碼</param>
        /// <returns>指定的Customers資料</returns>
        public async Task<Customers> GetCustomerById(int id)
        {
            const string query = "SELECT * FROM Customers WHERE CustomerId = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                var customer = await connection.QuerySingleOrDefaultAsync<Customers>(query, new { Id = id });
                return customer ?? new Customers();
            }
        }

        /// <summary>
        /// 新增Customers資料
        /// </summary>
        /// <paramname="customer">新增的Customers資料</param>
        /// <returns>新增後的Customers資料</returns>
        public async Task<Customers> CreateCustomer(CustomersForCreationDto customer)
        {
            const string query = "INSERT INTO Customers (Name, Email, Phone) OUTPUT INSERTED.* VALUES (@Name, @Email, @Phone)";
            using (var connection = _dbContext.CreateConnection())
            {
                var createdCustomer = await connection.QuerySingleAsync<Customers>(query, customer);
                return createdCustomer ?? new Customers();
            }
        }

        /// <summary>
        /// 更新Customers資料（依指定id）
        /// </summary>
        /// <param name="id">Customers的唯一識別碼</param>
        /// <param name="customer">更新的Customers資料</param>
        public async Task UpdateCustomer(int id, CustomersForUpdateDto customer)
        {
            const string query = "UPDATE Customers SET Name = @Name, Email = @Email, Phone = @Phone WHERE CustomerId = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { customer.Name, customer.Email, customer.Phone, Id = id });
            }
        }

        /// <summary>
        /// 刪除Customers資料（依指定id）
        /// </summary>
        /// <param name="id">Customers的唯一識別碼</param>
        public async Task DeleteCustomer(int id)
        {
            const string query = "DELETE FROM Customers WHERE CustomerId = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}

