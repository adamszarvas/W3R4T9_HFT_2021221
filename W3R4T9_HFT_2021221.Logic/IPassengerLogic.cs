using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021221.Logic
{
    public interface IPassengerLogic
    {
        //CRUD
        void Create(Passenger passenger);
        Passenger Read(int id);
        IEnumerable<Passenger> ReadAll();
        void Update(Passenger newPas);
        void Delete(int id);

        //Non CRUD
        IEnumerable<KeyValuePair<int, double>> AveragePassengerAgeByFlights();
        IEnumerable<KeyValuePair<int, int>> LongNamesByFlights();
    }
}
