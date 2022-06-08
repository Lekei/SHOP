using AspNetApp.interfaces;
using AspNetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetApp.Repository
{
    public class SpateRepository : IAllSpate
    {
        private readonly AppDBContent _appDbContent;
        public SpateRepository(AppDBContent appDbContent)
        {
            this._appDbContent = appDbContent;
        }
        public IEnumerable<Spate> Spates => _appDbContent.Spate.Include(c => c.Category);

        public IEnumerable<Spate> getFavSpates => _appDbContent.Spate.Where(p => p.isFavourite).Include(c => c.Category);

        public Spate getObjectSpate(int spateId) => _appDbContent.Spate.FirstOrDefault(p => p.id == spateId);
    }
}