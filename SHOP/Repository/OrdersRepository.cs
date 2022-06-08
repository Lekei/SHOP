using AspNetApp.interfaces;
using AspNetApp.Models;

namespace AspNetApp.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopSpate shopSpate;

        public OrdersRepository(AppDBContent appDBContent, ShopSpate shopSpate)
        {
            this.appDBContent = appDBContent;
            this.shopSpate = shopSpate;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var item = shopSpate.listShopItems;

            foreach (var el in item)
            {
                var orderDetails = new OrderDetail()
                {
                    SpateID = el.spate.id,
                    orderID = order.id,
                    price = el.spate.price
                };
                appDBContent.orderDetails.Add(orderDetails);
            }
            appDBContent.SaveChanges();
        }
    }
}