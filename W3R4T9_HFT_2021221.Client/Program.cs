using ConsoleTools;
using System.Collections.Generic;
using W3R4T9.Client;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService restService = new RestService("http://localhost:37184");
            
            var a1 = restService.Get<Airline>(2,"airline");
            a1.Name = "NewAir";

            var f1 = restService.Get<Flight>(5,"flight");
            f1.From = "Turkish";

            var p1 = restService.Get<Passenger>(7,"passenger");
            p1.Name = "Josh";

            var airlines = restService.Get<Airline>("airline");
            var flights = restService.Get<Flight>("flight");
            var passenger = restService.Get<Passenger>("passenger");

            var nc1 = restService.Get<KeyValuePair<string, double>>("airlinenc/get");
            var nc2 = restService.Get<KeyValuePair<int, double>>("flightnc/avgticket");
            var nc3 = restService.Get<KeyValuePair<string, double>>("flightnc/fullness");
            var nc4 = restService.Get<Flight>("flightnc/seatorder");
            var nc5 = restService.Get<KeyValuePair<int, double>>("passengernc/avgage");
            var nc6 = restService.Get<KeyValuePair<int, int>>("passengernc/longnames");

            var menu = new ConsoleMenu().
                Add("Airline.Create", () => restService.Post<Airline>(new Airline() { Name = "WizzAir" }, "airline")).
                Add("Flight.Create", () => restService.Post<Flight>(new Flight() { From = "Japan", Destination = "Moscow" }, "flight")).
                Add("Passenger.Create", () => restService.Post<Passenger>(new Passenger() { Name = "Jin" }, "passenger")).
                Add("Airline.Delete", () => restService.Delete(4, "airline")).
                Add("Flight.Delete", () => restService.Delete(10, "flight")).
                Add("Passenger.Delete", () => restService.Delete(5, "passenger")).
                Add("Airline.Update", () => restService.Put<Airline>(a1, "airline")).
                Add("Flight.Update", () => restService.Put<Flight>(f1, "flight")).
                Add("Passenger.Update", () => restService.Put<Passenger>(p1, "passenger")).
                Add("Exit", ConsoleMenu.Close);
            menu.Show();

           

        }




    }
}
