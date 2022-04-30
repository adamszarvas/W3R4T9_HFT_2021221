using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021221.Repository
{
    public interface IPassengerRepository
    {
        void Create(Passenger passenger);
        Passenger Read(int Id);
        IQueryable<Passenger> ReadAll();
        void Update(Passenger passenger);
        void Delete(int Id);
        
        

    }
}
