using Microsoft.EntityFrameworkCore;
using W3R4T9_HFT_2021221.Models;
using System;

namespace W3R4T9_HFT_2021221.Data
{
    public class DBContext : DbContext
    {
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public DBContext()
        {
           this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Flight>().HasOne(x => x.Airline).WithMany(y => y.Flights).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Passenger>().HasOne(x => x.Flight).WithMany(y => y.Passengers).OnDelete(DeleteBehavior.NoAction);


            Airline airline1 = new Airline() {ID =1, Name = "Ryanair", PassengersYearly = 27000000, Region = "Europe" };

            Airline airline2 = new Airline() { ID = 2, Name = "American Airlines", PassengersYearly = 95000000, Region = "America" };

            Airline airline3 = new Airline() { ID = 3, Name = "Turkish Airlines", PassengersYearly = 16600000, Region = "Turkish" };

            Flight flight1 = new Flight() { ID = 1, /*AirlineId = airline1.ID,*/ From = "UK", Destination = "Romania", Seats = 120, TicketPrice = 200 };

            Flight flight2 = new Flight() { ID = 2, /*/*AirlineId = airline1.ID*/ From = "Hungary", Destination = "France", Seats = 100, TicketPrice = 150 };

            Flight flight3 = new Flight() { ID = 3, /*AirlineId = airline2.ID,*/ From = "Los Angeles", Destination = "New York", Seats = 70, TicketPrice = 120 };

            Flight flight4 = new Flight() { ID = 4,/* AirlineId = airline2.ID,*/ From = "Texas", Destination = "Philadelphia", Seats = 50, TicketPrice = 110 };

            Flight flight5 = new Flight() { ID = 5, /*AirlineId = airline3.ID,*/ From = "Istanbul", Destination = "Izmir", Seats = 110, TicketPrice = 80 };

            Flight flight6 = new Flight() { ID = 6, /*AirlineId = airline3.ID,*/ From = "Bursa", Destination = "Mardin", Seats = 80, TicketPrice = 115 };


            Passenger passenger1 = new Passenger() { ID = 1, Age = 23, /*FlightId = flight1.ID,*/ Name = "James" };

            Passenger passenger2 = new Passenger() { ID = 2, Age = 45, /*FlightId = flight1.ID,*/ Name = "Sophia" };

            Passenger passenger3 = new Passenger() { ID = 3, Age = 22, /*FlightId = flight2.ID,*/ Name = "Mason" };

            Passenger passenger4 = new Passenger() { ID = 4, Age = 18, /*FlightId = flight2.ID*/ Name = "Isabella" };

            Passenger passenger5 = new Passenger() { ID = 5, Age = 54,/* FlightId = flight3.ID,*/ Name = "Lotte" };

            Passenger passenger6 = new Passenger() { ID = 6, Age = 38, /*FlightId = flight3.ID,*/ Name = "Giotto" };

            Passenger passenger7 = new Passenger() { ID = 7, Age = 49, /*FlightId = flight4.ID,*/ Name = "Xander" };

            Passenger passenger8 = new Passenger() { ID = 8, Age = 55, /*FlightId = flight4.ID,*/ Name = "Luis" };

            Passenger passenger9 = new Passenger() { ID = 9, Age = 31, /*FlightId = flight6.ID,*/ Name = "Adem" };

            Passenger passenger10 = new Passenger() { ID = 10, Age = 19, /*FlightId = flight5.ID,*/ Name = "Ahmet" };

            Passenger passenger11 = new Passenger() { ID = 11, Age = 56,/* FlightId = flight5.ID,*/ Name = "Emir" };

            Passenger passenger12 = new Passenger() { ID = 12, Age = 69, /*FlightId = flight6.ID,*/ Name = "Eymen" };

            modelBuilder.Entity<Airline>().HasData(airline1, airline2, airline3);

            modelBuilder.Entity<Passenger>().HasData(passenger1, passenger2, passenger3, passenger4, passenger5, passenger6, passenger7, passenger8, passenger9, passenger10, passenger11, passenger12);

            modelBuilder.Entity<Flight>().HasData(flight1, flight2, flight3, flight4, flight5, flight6);





        }

    }
}
