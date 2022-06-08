using AspNetApp.Models;

namespace AspNetApp
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Spate.Any())
            {
                content.AttachRange(

                    new Spate
                    {
                        name = "Intel Core I7",
                        shortDesc = "Процессор от Intel",
                        longDesc = "Лучший процессор в соотношении Цена=Качества",
                        img = "/img/tesla.jpg",
                        price = 15000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Процессоры"]
                    },
                    new Spate
                    {
                        name = "GTX 1660 TI",
                        shortDesc = "Рекомендуем",
                        longDesc = "Лучшее соотношение цена = качество",
                        img = "/img/tesla.jpg",
                        price = 20000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Видеокарты"]
                    },
                    new Spate
                    {
                        name = "RTX 3080",
                        shortDesc = "Самая дорогая",
                        longDesc = "Самая дорогая,но самая мощная",
                        img = "/img/fiesta.png",
                        price = 40000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Видеокарты"]
                    },
                    new Spate
                    {
                        name = "RTX 2070 Super",
                        shortDesc = "Средняя Видеокарта с RTX",
                        longDesc = "Неплохая альтернатива 1660 TI,но с технологией RTX",
                        img = "/img/bmw_m3.jpg",
                        price = 28000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Видеокарты"]
                    },
                    new Spate
                    {
                        name = "AMD Ryzen 5 2600",
                        shortDesc = "Рекомендуем",
                        longDesc = "Лучшее соотношение цена = качество",
                        img = "/img/tesla.jpg",
                        price = 10000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Процессоры"]
                    }

                    );
            }

            content.SaveChanges();

        }



        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                         new Category{categoryName = "Процессоры", desc = "Мозг компьютера"},
                         new Category {categoryName = "Видеокарты", desc = "Отвечает за графику на ПК"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        }
    }
}