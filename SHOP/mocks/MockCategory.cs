using AspNetApp.interfaces;
using AspNetApp.Models;

namespace AspNetApp.mocks
{
    public class MockCategory : ISpateCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{categoryName = "Процессоры", desc = "Мозг компьютера"},
                    new Category {categoryName = "Видеокарты", desc = "Отвечает за графику на ПК"}
                };
            }
        }
    }
}