using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Data;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021221.Repository
{
    public class PassengerReporitory : IPassengerRepository
    {
        DBContext DB;
        public PassengerReporitory(DBContext db)
        {
            this.DB = db;
        }

        public void Create(Passenger passenger)
        {
            DB.Passengers.Add(passenger);
            DB.SaveChanges();
        }

        public void Delete(int Id)
        {
            DB.Passengers.Remove(Read(Id));
            DB.SaveChanges();
        }

        public Passenger Read(int Id)
        {
            return DB.Passengers.FirstOrDefault(x => x.ID == Id);
        }

        public IQueryable<Passenger> ReadAll()
        {
            return DB.Passengers;
        }

        public void Update(Passenger passenger)
        {
            var old = Read(passenger.ID);
            old.Age = passenger.Age;
            old.Name = passenger.Name;
            DB.SaveChanges();

        }
    }
}
