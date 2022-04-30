using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Models;
using W3R4T9_HFT_2021221.Repository;

namespace W3R4T9_HFT_2021221.Logic
{
    public class PassengerLogic : IPassengerLogic
    {
        IPassengerRepository passengerRepo;

        public PassengerLogic(IPassengerRepository repo)
        {
            this.passengerRepo = repo;
        }

        
        public IEnumerable<KeyValuePair<int, double>> AveragePassengerAgeByFlights()
        {
            return from x in passengerRepo.ReadAll()
                    group x by x.Flight.ID into g
                    select new KeyValuePair<int, double>(g.Key,(double)g.Average(x => x.Age));
        }

        public IEnumerable<KeyValuePair<int, int>> LongNamesByFlights()
        {
            return from x in passengerRepo.ReadAll()
                   group x by x.Flight.ID into g
                   select new KeyValuePair<int, int>(g.Key, g.Count(t => t.Name.Length > 5));
        }

        public void Create(Passenger passenger)
        {
            if (passenger == null)
            {
                throw new ArgumentException();
            }
            else if (passenger.Age < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            passengerRepo.Create(passenger);
        }

        public void Delete(int id)
        {
            passengerRepo.Delete(id);
        }

        public Passenger Read(int id)
        {
            return passengerRepo.Read(id);
        }

        public IEnumerable<Passenger> ReadAll()
        {
            return passengerRepo.ReadAll();
        }

        public void Update(Passenger newPas)
        {
            if (newPas == null)
            {
                throw new ArgumentNullException();
            }
            passengerRepo.Update(newPas);
        }
    }
}
