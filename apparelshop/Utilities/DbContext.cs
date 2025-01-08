using System.Data;
using Microsoft.Data.SqlClient;
<<<<<<< HEAD
using Microsoft.Extensions.Configuration;
=======
>>>>>>> ec7c70ed4eed821ffac1aa9b43f25d5e76e4f3e5

namespace apparelshop.Utilities
{
    public class DbContext
    {
        // 用於儲存DI（Dependency Injection）的IConfiguration 實例
        private readonly IConfiguration _configuration;
        // 用來儲存資料庫連接字串
        private readonly string _connectionString;
        public DbContext(IConfiguration configuration)
        {
<<<<<<< HEAD
            // 讀取名稱為CalendarContext 的連接字串
            // 將其儲存在_connectionString 變數中
            //_configuration = configuration;
            //_connectionString = _configuration.GetConnectionString("DefaultContext");
            //_connectionString = configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        }

=======
            _configuration = configuration;
            // 讀取名稱為CalendarContext 的連接字串
            // 將其儲存在_connectionString 變數中
            _connectionString = _configuration.GetConnectionString("CalendarContext");
        }
        
>>>>>>> ec7c70ed4eed821ffac1aa9b43f25d5e76e4f3e5
        // 此方法可用於建立與資料庫的連線
        // 定義一個名為CreateConnection 的公共方法
        // 透過_connectionString 建立一個新的SqlConnection 實例
        public IDbConnection CreateConnection()
<<<<<<< HEAD
        {
            return new SqlConnection(_connectionString);
        }
=======
            => new SqlConnection(_connectionString);
>>>>>>> ec7c70ed4eed821ffac1aa9b43f25d5e76e4f3e5
    }
}
