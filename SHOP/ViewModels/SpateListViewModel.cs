using AspNetApp.Models;

namespace AspNetApp.ViewModels
{
    public class SpateListViewModel
    {
        public IEnumerable<Spate> allSpates { get; set; }

        public string currCategory { get; set; }
    }
}