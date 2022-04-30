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
    class AirlineTester
    {
        AirlineLogic al;
        public AirlineTester()
        {
            Mock<IAirLineRepository> mockAirlineRepo = new Mock<IAirLineRepository>();
            List<Flight> flights = new List<Flight>()
            {
                new Flight() { From = "Texas", Destination = "Philadelphia", Seats = 50, TicketPrice = 110 },
                new Flight() {  From = "UK", Destination = "Romania", Seats = 120, TicketPrice = 200 },
                new Flight() {  From = "Istanbul", Destination = "Izmir", Seats = 110, TicketPrice = 80 }
            };
            mockAirlineRepo.Setup((t) => t.Create(It.IsAny<Airline>()));
            mockAirlineRepo.Setup((t) => t.ReadAll()).Returns(
                new List<Airline>()
                {
                    new Airline()
                    {
                        Name = "Ryanair",
                        Flights = flights   
                    },
                    new Airline()
                    {
                        Name = "American Airlines",
                        Flights = flights
                    }

                } .AsQueryable());

            al = new AirlineLogic(mockAirlineRepo.Object);

        }

        [TestCase("TestAirline", true)]
        [TestCase(null, false)]
        public void CreateTester(string name, bool result)
        {
            if (result)
            {
                Assert.That(() => al.Create(new Airline()
                {
                    Name = name
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => al.Create(new Airline()
                {
                    Name = name
                }), Throws.Exception);
            }
        }

        [Test]
        public void CreateWithNullArgument()
        {
            Assert.That(() => al.Create(null), Throws.Exception);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void UpdateExceptionTester(bool result)
        {
           Airline test = new Airline() { Name = "Turkish Airlines", PassengersYearly = 16600000, Region = "Turkish" };


            if (result)
            {
                Assert.That(() => al.Update(test), Throws.Nothing);
            }
            else
            {
                Assert.That(() => al.Update(null), Throws.Exception);
            }
        }

        [Test]
        public void HugeFlightsByAirlinesTest()
        {
            var result = al.HugeFlightsByAirlines().ToArray();

            Assert.That(result[0], Is.EqualTo(
                new KeyValuePair<string,int>("Ryanair",2)));

        }

    }
}
