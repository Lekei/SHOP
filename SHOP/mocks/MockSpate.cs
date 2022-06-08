using AspNetApp.interfaces;
using AspNetApp.Models;

namespace AspNetApp.mocks
{
    public class MockSpate : IAllSpate
    {
        private readonly ISpateCategory _categorySpates = new MockCategory();
        public IEnumerable<Spate> Spates
        {
            get
            {
                return new List<Spate>
                {
                    new Spate
                    {
                        name = "AMD Ryzen 5 2600",
                        shortDesc = "Рекомендуем",
                        longDesc = "Лучшее соотношение цена = качество",
                        img = "/img/Ryzen 5.jpg",
                        price = 10000,
                        isFavourite = true,
                        available = true,
                        Category = _categorySpates.AllCategories.First()
                    },
                    new Spate
                    {
                        name = "RTX 3080",
                        shortDesc = "Самая дорогая",
                        longDesc = "Самая дорогая,но самая мощная",
                        img = "/img/RTX 3080.jpg",
                        price = 40000,
                        isFavourite = true,
                        available = true,
                        Category = _categorySpates.AllCategories.Last()
                    },
                    new Spate
                    {
                        name = "RTX 2070 Super",
                        shortDesc = "Средняя Видеокарта с RTX",
                        longDesc = "Неплохая альтернатива 1660 TI,но с технологией RTX",
                        img = "/img/RTX-2070-SUPER.jpg",
                        price = 28000,
                        isFavourite = true,
                        available = true,
                        Category = _categorySpates.AllCategories.Last()
                    },
                    new Spate
                    {
                        name = "GTX 1660 TI",
                        shortDesc = "Рекомендуем",
                        longDesc = "Лучшее соотношение цена = качество",
                        img = "/img/GTX 1660 TI.jpg",
                        price = 20000,
                        isFavourite = true,
                        available = true,
                        Category = _categorySpates.AllCategories.Last()
                    },
                    new Spate
                    {
                        name = "Intel Core I7",
                        shortDesc = "Процессор от Intel",
                        longDesc = "Лучший процессор в соотношении Цена=Качества",
                        img = "/img/Intel I7.jpg",
                        price = 15000,
                        isFavourite = true,
                        available = true,
                        Category = _categorySpates.AllCategories.First()
                    }

                };
            }
        }
        public IEnumerable<Spate> getFavSpates { get; set; }

        public Spate getObjectSpate(int carId)
        {
            throw new NotImplementedException();
        }
    }
}