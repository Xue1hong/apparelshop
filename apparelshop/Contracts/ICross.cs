using System.Globalization;
using apparelshop.Dtos;
using apparelshop.Models;
namespace apparelshop.Contracts
{
    public interface ICross
    {
        // 查詢所有訂單列表
        public Task<IEnumerable<Orders>> GetAllOrders();

        //新增訂單
        public Task<Orders> AddOrder(Orders order);
        // 查詢Member 和他/她參與的所有Calendars 資料（依指定id）
        //public Task<CalendarsOfMember> GetCalendarsByMemberId(Guid id);

        // 查詢Products 和他/她參與的所有Customers 資料（依指定id）
        public Task<CustomersOfProducts> GetCustomersByProductsId(int id);

        // 查詢Member 和他/她參與的所有Calendars 的詳細資料（依指定id）
        // public Task<CalendarDetailsOfMember> GetCalendarDetailsByMemberId(Guid id);
        public Task<ProductsDetailsOfCustomers> GetProductsDetailsByCustomersId(int id);



        // 查詢Calendar 和參與其中的所有Members 資料（依指定id）
        //public Task<MembersOfCalendar> GetMembersByCalendarId(int id);

        // 查詢Customers 和參與其中的所有Products 資料（依指定id）
        public Task<ProductsOfCustomers> GetProductsByCustomersId(int id);
        // 查詢Calendar 和參與其中的所有Members 的詳細資料（依指定id）
        // public Task<MemberDetailsOfCalendar> GetMemberDetailsByCalendarId(int id);
        public Task<CustomersDetailsOfProducts> GetCustomersDetailsByProductsId(int id);






    }
}
