using apparelshop.Contracts;
using apparelshop.Utilities;
using apparelshop.Dtos;
using Dapper;
using apparelshop.Repositories;
using apparelshop.Models;


namespace apparelshop.Repositories
{
    public class CrossRepository : ICross
    {
        private readonly DbContext _dbContext;

        public CrossRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //查詢所有訂單列表
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            const string query = "SELECT * FROM Orders";
            using (var connection = _dbContext.CreateConnection())
            {
                var orders = await connection.QueryAsync<Orders>(query);
                return orders ?? new List<Orders>();
            }
        }
        //新增訂單
        public async Task<Orders> AddOrder(Orders order)
        {
            const string query = "INSERT INTO Orders (OrderDate, Quantity, ProductID, CustomerID) " +
                "VALUES (@OrderDate, @Quantity, @ProductID, @CustomerID); " +
                "SELECT * FROM Orders WHERE OrderID = SCOPE_IDENTITY();";
            using (var connection = _dbContext.CreateConnection())
            {
                var newOrder = await connection.QuerySingleOrDefaultAsync<Orders>(query, order);
                return newOrder;
            }
        }

        // 查詢Customer 和他/她購買的所有Products 資料（依指定CustomerID）
        public async Task<ProductsOfCustomers> GetProductsByCustomersId(int customerId)
        {
            string sqlQuery = @"
                SELECT CustomerID, Name, Phone, Email 
                FROM Customers 
                WHERE CustomerID = @CustomerId;

                SELECT P.ProductID, P.Name AS ProductName, P.Color, P.Category, P.Price, O.Quantity 
                FROM Products P
                INNER JOIN Orders O ON P.ProductID = O.ProductID
                WHERE O.CustomerID = @CustomerId;
            ";

            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { CustomerId = customerId });

                var customer = await multi.ReadSingleOrDefaultAsync<ProductsOfCustomers>();
                if (customer != null)
                {
                    customer.Products = (await multi.ReadAsync<String>()).ToList();
                }
                return customer;
            }
        }

        // 查詢Products 和他/她參與的所有Customers 的詳細資料（依指定id）
        public async Task<CustomersDetailsOfProducts> GetCustomersDetailsByProductsId(int id)
        {
            string sqlQuery = "SELECT Mid, Mname, Mphone FROM Member WHERE Mid = @Id;" +
                "SELECT C.* FROM Calendar C, CalendarJoin J " +
                "WHERE J.Mid = @Id AND C.Cid = J.Cid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
                var products = await multi.ReadSingleOrDefaultAsync<CustomersDetailsOfProducts>();
                if (products != null)
                    products.Customers = (await multi.ReadAsync<Customers>()).ToList();
                return products;
            }
        }



        // 查詢Customer 和他/她參與的所有Orders 資料（依指定CustomerID）
        public async Task<OrdersOfCustomers> GetOrdersByCustomerId(int customerId)
        {
            string sqlQuery = @"
                SELECT CustomerID, Name, Phone, Email 
                FROM Customers 
                WHERE CustomerID = @CustomerId;

                SELECT O.OrderID, O.OrderDate, O.Quantity, P.Name AS ProductName 
                FROM Orders O
                INNER JOIN Products P ON O.ProductID = P.ProductID
                WHERE O.CustomerID = @CustomerId;
            ";

            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { CustomerId = customerId });

                var customer = await multi.ReadSingleOrDefaultAsync<OrdersOfCustomers>();
                if (customer != null)
                {
                    customer.Orders = (await multi.ReadAsync<String>()).ToList();
                }
                return customer;
            }
        }

        // 查詢Product 和購買此Product 的所有Customers 資料（依指定ProductID）
        public async Task<CustomersOfProducts> GetCustomersByProductsId(int productId)
        {
            string sqlQuery = @"
                SELECT ProductID, Name AS ProductName, Color, Category, Price, Stock 
                FROM Products 
                WHERE ProductID = @ProductId;

                SELECT C.CustomerID, C.Name AS CustomerName, C.Phone, C.Email, O.Quantity 
                FROM Customers C
                INNER JOIN Orders O ON C.CustomerID = O.CustomerID
                WHERE O.ProductID = @ProductId;
            ";

            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { ProductId = productId });

                var product = await multi.ReadSingleOrDefaultAsync<CustomersOfProducts>();
                if (product != null)
                {
                    product.Customers = (await multi.ReadAsync<Customers>()).Select(c => c.Name).ToList();
                }
                return product;
            }
        }

        // 查詢Customers和參與的所有Products 的詳細資料（依指定id）
        public async Task<ProductsDetailsOfCustomers> GetProductsDetailsByCustomersId(int id)
        {
            string sqlQuery = "SELECT Cid, Cname FROM Calendar WHERE Cid = @Id;" +
                "SELECT M.* FROM Member M, CalendarJoin J " +
                "WHERE J.Cid = @Id AND M.Mid = J.Mid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id= id });
                var customers = await multi.ReadSingleOrDefaultAsync<ProductsDetailsOfCustomers>();
                if (customers != null)
                    customers.Products = (await multi.ReadAsync<Products>()).
                        ToList();return customers;
            }
        }

    }
}
