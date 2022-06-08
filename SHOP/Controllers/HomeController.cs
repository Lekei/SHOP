using AspNetApp.interfaces;
using AspNetApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllSpate _allSpate;
        private readonly AppDBContent _db;
        public HomeController(IAllSpate iAllSpate, AppDBContent db)
        {
            _allSpate = iAllSpate;
            _db = db;
        }

        public async Task<IActionResult> Index(string Empsearch)
        {
            HomeViewModel homeSpate;

            ViewData["Getemployeedetails"] = Empsearch;
            var empquery = from x in _db.Spate select x;
            if (!String.IsNullOrEmpty(Empsearch))
            {
                empquery = empquery.Where(x => x.name.Contains(Empsearch) || x.Category.categoryName.Contains(Empsearch));

                homeSpate = new HomeViewModel
                {
                    favSpates = await empquery.AsNoTracking().ToListAsync()
                };
            }
            else
            {
                homeSpate = new HomeViewModel
                {
                    favSpates = _allSpate.getFavSpates
                };
            }

            return View(homeSpate);
        }
    }
}