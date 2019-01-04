using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public interface ISamochodRepository
    {
        IEnumerable<Samochod> PobierzWszystkieSamochody(); // metoda zwracająca wszystkie samochody
        Samochod PobierzSamochodOId(int samochodId); // pobieranie pojedynczego samochodu o wybranym Id


    }
}
