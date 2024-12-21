using System.Data;
using Microsoft.Data.SqlClient;

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
            _configuration = configuration;
            // 讀取名稱為CalendarContext 的連接字串
            // 將其儲存在_connectionString 變數中
            _connectionString = _configuration.GetConnectionString("CalendarContext");
        }
        
        // 此方法可用於建立與資料庫的連線
        // 定義一個名為CreateConnection 的公共方法
        // 透過_connectionString 建立一個新的SqlConnection 實例
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
