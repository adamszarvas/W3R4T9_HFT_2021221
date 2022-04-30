using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Logic;
using W3R4T9_HFT_2021221.Models;
using W3R4T9_HFT_2021221.Repository;

namespace W3R4T9_HFT_2021221.Test
{
    [TestFixture]
    public class FlightTester
    {
        FlightLogic fl;
        public FlightTester()
        {
            Mock<IFlightRepository> mockFlightRepo = new Mock<IFlightRepository>();
            Airline fakeAirline = new Airline() { Name = "Ryanair"};
            ICollection<Passenger> fakePassengers = new HashSet<Passenger>();
            fakePassengers.Add( new Passenger() { Age = 23,  Name = "James" });
            fakePassengers.Add(new Passenger() { Age = 45,  Name = "Sophia" });

            mockFlightRepo.Setup((t) => t.Create(It.IsAny<Flight>()));
            mockFlightRepo.Setup((t) => t.ReadAll()).Returns(
                new List<Flight>()
                {
                    new Flight()
                    {
                        Airline = fakeAirline,
                        From = "UK",
                        Destination = "Romania",
                        Seats = 10,
                        TicketPrice = 200,
                        Passengers = fakePassengers

                    },

                    new Flight()
                    {
                        Airline = fakeAirline, 
                        From = "Hungary", 
                        Destination = "France", 
                        Seats = 100, 
                        TicketPrice = 150,
                        Passengers = fakePassengers
                    }
                }.AsQueryable()
              );
            
            fl = new FlightLogic(mockFlightRepo.Object);
        }

        
        [TestCase("fromTest", "toTest",true)]
        [TestCase(null, "toTest", false)]
        [TestCase("fromTest", null, false)]
        public void CreateTester(string from, string to, bool result )
        {
            if (result)
            {
                Assert.That(() => fl.Create(new Flight()
                {
                    From = from,
                    Destination = to
                }),Throws.Nothing);
            }
            else
            {
                Assert.That(() => fl.Create(new Flight()
                {
                    From = from,
                    Destination = to
                }), Throws.Exception);
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public void UpdateExceptionTester(bool result)
        {
            Flight test = new Flight() { Destination = "TestDes", From = "TestFrom" };


            if (result)
            {
                Assert.That(() => fl.Update(test), Throws.Nothing);
            }
            else
            {
                Assert.That(() => fl.Update(null), Throws.Exception );
            }
        }

        [Test]
        public void AverageTicketPriceByAirlines()
        {
            var avg = fl.AverageTicketPriceByAirlines().ToArray();

            Assert.That(avg[0],
                Is.EqualTo(new KeyValuePair<int,double>(0,175)));
        }

        [Test]
        public void FlightsFullness()
        {
            var result = fl.FlightsFullness().ToArray();

            Assert.That(result[0],
                Is.EqualTo(new KeyValuePair<string, int>("UK", 20))
                );
        }

        [Test]
        public void FlightsOrderedBySeats()
        {
            var result = fl.FlightsOrderedBySeats();
            var expect = fl.ReadAll().OrderBy(x => x.Seats).ToList();

            Assert.That(result,Is.EqualTo(expect));

        }

    }
}
