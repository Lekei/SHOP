using AspNetApp.interfaces;
using AspNetApp.Models;
using AspNetApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApp.Controllers
{
    public class ShopSpateController : Controller
    {
        private readonly IAllSpate _spateRep;
        private readonly ShopSpate _shopSpate;

        public ShopSpateController(IAllSpate spateRep, ShopSpate shopSpate)
        {
            _spateRep = spateRep;
            _shopSpate = shopSpate;
        }

        public ViewResult Index(bool coincidence = false)
        {
            ShopSpateViewModel ShopCartItemS = new ShopSpateViewModel()
            { ShopSpateItem = _shopSpate.getShopSpateItems() };

            ViewBag.coincidence = coincidence;

            return View(ShopCartItemS);
        }

        public RedirectToActionResult addToSpate(int id)
        {
            bool coincidence = false;

            if (_spateRep.Spates.FirstOrDefault(i => i.id == id) != null)
            {
                _shopSpate.listShopItems = _shopSpate.getShopSpateItems();

                foreach (var el in _shopSpate.listShopItems)
                {
                    if (el.spate.id == id)
                    {
                        coincidence = true;
                        break;
                    }
                }

                if (!coincidence)
                    _shopSpate.AddToCart(_spateRep.Spates.FirstOrDefault(i => i.id == id));

            }

            if (coincidence)
            {
                return RedirectToAction("Index", new { coincidence = true });
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public RedirectToActionResult deleteToSpate(int id)
        {

            _shopSpate.DeleteToSpate(id);

            return RedirectToAction("Index");
        }
    }
}