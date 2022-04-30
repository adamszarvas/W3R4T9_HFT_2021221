using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Data;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021221.Repository
{
    public class FlightRepository : IFlightRepository
    {
        DBContext DB;
        public FlightRepository(DBContext DB)
        {
            this.DB = DB;
        }

        public void Create(Flight flight)
        {
            DB.Flights.Add(flight);
            DB.SaveChanges();
        }

        public void Delete(int Id)
        {
            DB.Flights.Remove(Read(Id));
            DB.SaveChanges();
        }

        public Flight Read(int Id)
        {
            return DB.Flights.FirstOrDefault(x => x.ID == Id);
        }

        public IQueryable<Flight> ReadAll()
        {
            return DB.Flights;
        }

        public void Update(Flight flight)
        {
            var old = Read(flight.ID);
            old.Destination = flight.Destination;
            old.From = flight.From;
            old.Seats = flight.Seats;
            old.TicketPrice = flight.TicketPrice;
            DB.SaveChanges();
            
        }
    }
}
