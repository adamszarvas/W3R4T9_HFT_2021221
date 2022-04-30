using MovieDbApp.WpfClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021222.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Airline> Airlines { get; set; }
        public MainWindowViewModel()
        {
           Airlines = new RestCollection<Airline>("http://localhost:5000","Airline");
        }
    }
}
