using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Data;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021221.Repository
{
    public class AirlineRepository : IAirLineRepository
    {
        DBContext DB;
        public AirlineRepository(DBContext DB)
        {
            this.DB = DB;
        }


        public void Create(Airline airL)
        {
            DB.Airlines.Add(airL);
            DB.SaveChanges();
        }

        public void Delete(int Id)
        {
            DB.Airlines.Remove(Read(Id));
            DB.SaveChanges();
        }

        public Airline Read(int Id)
        {
            return DB.Airlines.FirstOrDefault(x => x.ID.Equals(Id));
        }

        public IQueryable<Airline> ReadAll()
        {
            return DB.Airlines;

        }

        public void Update(Airline airL)
        {
            var old = Read(airL.ID);
            old.Name = airL.Name;
            old.PassengersYearly = airL.PassengersYearly;
            old.Region = airL.Region;
            DB.SaveChanges();
        }
    }
}
