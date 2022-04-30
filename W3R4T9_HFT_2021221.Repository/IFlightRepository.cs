using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021221.Repository
{
    public interface IFlightRepository
    {
        void Create(Flight flight);
        Flight Read(int Id);
        IQueryable<Flight> ReadAll();
        void Update(Flight flight);
        void Delete(int Id);
    }
}
