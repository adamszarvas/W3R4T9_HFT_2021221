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
    public class PassengerTester
    {
        PassengerLogic pl;
        
        public PassengerTester()
        {
            Flight fakeFlight = new Flight() { 
                ID = 1,
                From = "Bursa", 
                Destination = "Mardin", 
                Seats = 80, 
                TicketPrice = 115, 
            };
            Mock<IPassengerRepository> mockPassengerRepo = new Mock<IPassengerRepository>();
            mockPassengerRepo.Setup((t) => t.Create(It.IsAny<Passenger>()));
            mockPassengerRepo.Setup((t) => t.ReadAll()).Returns(
                new List<Passenger>()
                {
                    new Passenger() { Age = 23, Name = "James" },
                    new Passenger() { Age = 45, Name = "Sophia" }

                }.AsQueryable()
                );
            pl = new PassengerLogic(mockPassengerRepo.Object);

        }

        [TestCase("testName",20,true)]
        [TestCase(null,20, false)]
        [TestCase("testName", 0, false)]
        public void CreateTester( string name, int age, bool result)
        {
            if (result)
            {
                Assert.That(() => pl.Create(new Passenger()
                {
                    Name = name,
                    Age = age

                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => pl.Create(new Passenger()
                {
                    Name = name,
                    Age = age
                }), Throws.Exception);
            }
        }

        [Test]
        public void CreateTesterWithNullReference()
        {
            Assert.That(() => pl.Create(null),Throws.Exception);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void UpdateExceptionTester(bool result)
        {
            Passenger ps = new Passenger() { Age = 23, Name = "James" };


            if (result)
            {
                Assert.That(() => pl.Update(ps), Throws.Nothing);
            }
            else
            {
                Assert.That(() => pl.Update(null), Throws.Exception);
            }
        }

        [Test]
        public void AveragePassengerAgeByFlights()
        {
            var result = pl.AveragePassengerAgeByFlights().ToArray();

            Assert.That(result[0],Is.EqualTo(
                new KeyValuePair<int,double>(1,34)));
        }

        [Test]
        public void LongNamesByFlights()
        {
            var result = pl.LongNamesByFlights().ToArray();

            Assert.That(result[0], Is.EqualTo(
                new KeyValuePair<int,int>(1,1)));
        }
    }
}
