using AspNetApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AspNetApp
{
    public class AppDBContent : DbContext
    {
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        { }
        public DbSet<Spate> Spate { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopSpateItem> ShopSpateItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
    }

}