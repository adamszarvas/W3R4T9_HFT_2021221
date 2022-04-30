using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Models;
using W3R4T9_HFT_2021221.Repository;

namespace W3R4T9_HFT_2021221.Logic
{
    public class FlightLogic : IFlightLogic
    {
        IFlightRepository flightRepo;

        public FlightLogic(IFlightRepository repo)
        {
            this.flightRepo = repo;
        }

        public IEnumerable<KeyValuePair<int, double>> AverageTicketPriceByAirlines()
        {
            return from x in flightRepo.ReadAll()
                   group x by x.Airline.ID into g
                   select new KeyValuePair<int, double>(g.Key, (double)g.Average(t => t.TicketPrice));

        }

        public IEnumerable<KeyValuePair<string, double>> FlightsFullness()
        {
            return from x in flightRepo.ReadAll()
                   select new KeyValuePair<string, double>(x.From,
                   (double)(x.Passengers.Count() * 100 / x.Seats));
        }

        public IEnumerable<Flight> FlightsOrderedBySeats()
        {
            return flightRepo.ReadAll().OrderBy(x => x.Seats);
        }

        public void Create(Flight flight)
        {
            if (flight.Destination == null || flight == null)
            {
                throw new ArgumentNullException();
            }
            flightRepo.Create(flight);
        }

        public void Delete(int id)
        {
            flightRepo.Delete(id);
        }

        public Flight Read(int id)
        {
            return flightRepo.Read(id);
        }

        public IEnumerable<Flight> ReadAll()
        {
            return flightRepo.ReadAll();
        }

        public void Update(Flight newFlight)
        {
            if (newFlight == null)
            {
                throw new ArgumentNullException();
            }
            flightRepo.Update(newFlight);
        }


    }
}
