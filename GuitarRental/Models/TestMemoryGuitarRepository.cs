using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarRental.Models
{
    public class TestMemoryGuitarRepository : ICRUDGuitarRepository
    {
        private Dictionary<int, Guitar> guitarss = new Dictionary<int, Guitar>();
        private int Index = 1;

        public TestMemoryGuitarRepository()
        {
            guitarss.Add(1, new Guitar()
            {
                Name = "Fender Stratocaster",
                GuitarId = Index++,
                ProductionYear = 2000,
                GuitarTypeId = 2,
                GuitarStringsId = 2
            });
            guitarss.Add(2, new Guitar()
            {
                Name = "Fender Telecaster",
                GuitarId = Index++,
                ProductionYear = 2001,
                GuitarTypeId = 2,
                GuitarStringsId = 2
            });
        }

        public Guitar Add(Guitar guitar)
        {
            guitar.GuitarId = Index++;
            guitarss.Add(guitar.GuitarId, guitar);
            return guitar;
        }

        public void Delete(int id)
        {
            guitarss.Remove(id);
        }

        public IList<Guitar> FindAll()
        {
            return guitarss.Values.ToList();
        }

        public Guitar FindById(int id)
        {
            if (guitarss.TryGetValue(id, out var guitar))
            {
                return guitar;
            }
            else
            {
                return null;
            }
        }

        public Guitar Update(Guitar guitar)
        {
            throw new NotImplementedException();
        }
    }
}
