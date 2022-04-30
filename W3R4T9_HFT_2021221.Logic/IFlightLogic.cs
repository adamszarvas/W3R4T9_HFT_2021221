using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021221.Logic
{
    public interface IFlightLogic
    {
        //CRUD
        void Create(Flight flight);
        Flight Read(int id);
        IEnumerable<Flight> ReadAll();
        void Update(Flight newFlight);
        void Delete(int id);

        //Non CRUD
        IEnumerable<KeyValuePair<int, double>> AverageTicketPriceByAirlines();
        IEnumerable<KeyValuePair<string, double>> FlightsFullness();
        IEnumerable<Flight> FlightsOrderedBySeats();
    }
}
