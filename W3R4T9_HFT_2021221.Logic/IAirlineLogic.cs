using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021221.Logic
{
    public interface IAirlineLogic
    {
        //CRUD
        void Create(Airline airline);
        Airline Read(int id);
        IEnumerable<Airline> ReadAll();
        void Update(Airline newAirline);
        void Delete(int id);

        //Non CRUD
        IEnumerable<KeyValuePair<string, int>> HugeFlightsByAirlines();
    }
}
