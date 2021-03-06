using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021221.Repository
{
    public interface IAirLineRepository
    {
        void Create(Airline airL);
        Airline Read(int Id);
        IQueryable<Airline> ReadAll();
        void Update(Airline airL);
        void Delete(int Id);

    }
}
