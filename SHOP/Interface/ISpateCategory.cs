using AspNetApp.Models;

namespace AspNetApp.interfaces
{
    public interface ISpateCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}