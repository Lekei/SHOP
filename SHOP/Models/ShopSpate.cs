using Microsoft.EntityFrameworkCore;

namespace AspNetApp.Models
{
    public class ShopSpate
    {
        private readonly AppDBContent appDBContent;
        public ShopSpate(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopSpateId { get; set; }
        public List<ShopSpateItem> listShopItems { get; set; }

        public static ShopSpate GetSpate(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string shopSpateId = session.GetString("SpateId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopSpateId);

            return new ShopSpate(context) { ShopSpateId = shopSpateId };
        }

        public void AddToCart(Spate spate)
        {
            this.appDBContent.ShopSpateItems.Add(new ShopSpateItem
            {
                ShopSpateId = ShopSpateId,
                spate = spate,
                price = spate.price
            });

            appDBContent.SaveChanges();
        }

        public void DeleteToSpate(int id)
        {
            appDBContent.ShopSpateItems.Remove(new ShopSpateItem
            {
                id = id
            });

            appDBContent.SaveChanges();
        }

        public List<ShopSpateItem> getShopSpateItems()
        {
            return appDBContent.ShopSpateItems.Where(c => c.ShopSpateId == ShopSpateId).Include(c => c.spate).ToList();
        }

    }
}