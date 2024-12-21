using apparelshop.Contracts;
using apparelshop.Dtos;
using apparelshop.Models;
using Dapper;
using System.Data;

namespace apparelshop.Repositories
{
    public class ProductsRepository : IProducts
    {
        private readonly IDbConnection _dbConnection;

        public ProductsRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// 查詢所有 Products 資料
        /// </summary>
        /// <returns>所有商品的資料集合</returns>
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            const string query = "SELECT * FROM Products";
            return await _dbConnection.QueryAsync<Products>(query);
        }

        /// <summary>
        /// 查詢單一 Products 資料（依指定 id）
        /// </summary>
        /// <paramname="id">商品的唯一識別碼</param>
        /// <returns>指定商品的資料</returns>
        public async Task<Products> GetProductById(int id)
        {
            const string query = "SELECT * FROM Products WHERE ProductID = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Products>(query, new { Id = id });

        }

        /// <summary>
        /// 新增 Products 資料
        /// </summary>
        /// <paramname="product">新增的商品資料</param>
        /// <returns>新增商品的資料</returns>
        public async Task<ProductsForCreationDto> CreateProduct(ProductsForCreationDto product)
        {
            const string query = "INSERT INTO Products (Name, Color, Category, Price, Stock) OUTPUT INSERTED.* VALUES (@Name, @Color, @Category, @Price, @Stock)";
            return await _dbConnection.QuerySingleAsync<ProductsForCreationDto>(query, product);
        }

        /// <summary>
        /// 更新 Products 資料（依指定 id）
        /// </summary>
        /// <paramname="id">商品的唯一識別碼</param>
        /// <paramname="product">更新的商品資料</param>
        /// <returns>Task</returns>
        public async Task UpdateProduct(int id, ProductsForUpdateDto product)
        {
            const string query = "UPDATE Products SET Name = @Name, Color = @Color, Category = @Category, Price = @Price, Stock = @Stock WHERE ProductID = @Id";
            await _dbConnection.ExecuteAsync(query, new { product.Name, product.Color, product.Category, product.Price, product.Stock, Id = id });
        }

        /// <summary>
        /// 刪除 Products 資料（依指定 id）
        /// </summary>
        /// <paramname="id">商品的唯一識別碼</param>
        /// <returns>Task</returns>
        public async Task DeleteProduct(int id)
        {
            const string query = "DELETE FROM Products WHERE ProductID = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}








