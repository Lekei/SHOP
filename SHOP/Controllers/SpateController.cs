using AspNetApp.interfaces;
using AspNetApp.Models;
using AspNetApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApp.Controllers
{
    public class SpateController : Controller
    {
        private readonly IAllSpate _allSpate;
        private readonly ISpateCategory _allCategories;


        public SpateController(IAllSpate iAllspate, ISpateCategory iSpateCat)
        {
            _allSpate = iAllspate;
            _allCategories = iSpateCat;

        }
        /*[Route("{url}")]*/
        /*[Route("Car")]
        [Route("Car/{url}")]*/
        [Route("Spates/List")]
        [Route("Spates/List/{url}")]
        public ViewResult List(string url)
        {
            IEnumerable<Spate> spates = null;
            string currCategory = "Запчасти";

            if (string.IsNullOrEmpty(url))
            {
                spates = _allSpate.Spates.OrderBy(spate => spate.price);
            }
            if (string.Equals("processor", url, StringComparison.OrdinalIgnoreCase))
            {
                spates = _allSpate.Spates.Where(spate => spate.Category.categoryName.Equals("Процессор")).OrderBy(spate => spate.price);
                currCategory = "Процессор";
            }
            if (string.Equals("video cards", url, StringComparison.OrdinalIgnoreCase))
            {
                spates = _allSpate.Spates.Where(spate => spate.Category.categoryName.Equals("Видеокарты")).OrderBy(spate => spate.price);
                currCategory = "Видеокарты";
            }

            SpateListViewModel spateObj = new SpateListViewModel
            {
                allSpates = spates,
                currCategory = currCategory
            };

            ViewBag.Title = "Страница с запчастями";

            return View(spateObj);
        }
    }
}