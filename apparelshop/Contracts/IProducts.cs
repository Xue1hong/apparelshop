
using apparelshop.Dtos;
using apparelshop.Models;

namespace apparelshop.Contracts
{
    public interface IProducts
    {
        /// <summary>
        /// 查詢所有 Products 資料
        /// </summary>
        /// <returns>所有商品的資料集合</returns>
        Task<IEnumerable<Products>> GetAllProducts();

        /// <summary>
        /// 查詢單一 Products 資料（依指定 id）
        /// </summary>
        /// <paramname="id">商品的唯一識別碼</param>
        /// <returns>指定商品的資料</returns>
        Task<Products> GetProductById(int id);

        /// <summary>
        /// 新增 Products 資料
        /// </summary>
        /// <paramname="product">新增的商品資料</param>
        /// <returns>新增商品的資料</returns>
        Task<ProductsForCreationDto> CreateProduct(ProductsForCreationDto product);

        /// <summary>
        /// 更新 Products 資料（依指定 id）
        /// </summary>
        /// <paramname="id">商品的唯一識別碼</param>
        /// <paramname="product">更新的商品資料</param>
        /// <returns>Task</returns>
        Task UpdateProduct(int id, ProductsForUpdateDto product);

        /// <summary>
        /// 刪除 Products 資料（依指定 id）
        /// </summary>
        /// <paramname="id">商品的唯一識別碼</param>
        /// <returns>Task</returns>
        Task DeleteProduct(int id);
    }
}
