using AspNetApp.Models;

namespace AspNetApp.interfaces
{
    public interface IAllSpate
    {
        IEnumerable<Spate> Spates { get; }
        IEnumerable<Spate> getFavSpates { get; }
        Spate getObjectSpate(int carId);
    }
}