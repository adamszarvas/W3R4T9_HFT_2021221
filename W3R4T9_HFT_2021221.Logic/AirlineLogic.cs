using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Models;
using W3R4T9_HFT_2021221.Repository;

namespace W3R4T9_HFT_2021221.Logic
{
    public class AirlineLogic : IAirlineLogic
    {

        IAirLineRepository airLineRepo;
        public AirlineLogic(IAirLineRepository Repo)
        {
            this.airLineRepo = Repo;
        }

        public IEnumerable<KeyValuePair<string, int>> HugeFlightsByAirlines()
        {
            return  from x in airLineRepo.ReadAll()
                    select new KeyValuePair<string, int>(x.Name, x.Flights.Count(x => x.Seats > 100));    
        }

        public void Create(Airline airline)
        {
            if (airline.Name == null || airline == null)
            {
                throw new ArgumentNullException();
            }
            airLineRepo.Create(airline);
        }

        public void Delete(int id)
        {
            airLineRepo.Delete(id);
        }

        public Airline Read(int id)
        {
            return airLineRepo.Read(id);
        }

        public IEnumerable<Airline> ReadAll()
        {
            return airLineRepo.ReadAll();
        }

        public void Update(Airline newAirline)
        {
            if (newAirline == null)
            {
                throw new ArgumentNullException();
            }
            airLineRepo.Update(newAirline);
        }
    }
}
