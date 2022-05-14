using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MovieDbApp.RestClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using W3R4T9_HFT_2021221.Models;

namespace W3R4T9_HFT_2021221.WpfClient.ViewModels
{
    public class FlightEditorWindowViewModel : ObservableRecipient
    {
        public RestCollection<Flight> Flights { get; set; }

        private Flight selectedFlight;
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public Flight SelectedFlight
        {
            get { return selectedFlight; }
            set
            {
                if (value != null)
                {
                    selectedFlight = new Flight()
                    {
                        From = value.From,
                        Destination = value.Destination,
                        Seats = value.Seats,
                        TicketPrice = value.TicketPrice,
                        ID = value.ID   
                    };
                    OnPropertyChanged();
                    (DeleteFlight as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateFlight as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        public ICommand CreateFlight { get; set; }
        public ICommand DeleteFlight { get; set; }
        public ICommand UpdateFlight { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public FlightEditorWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Flights = new RestCollection<Flight>("http://localhost:5000/", "Flight", "hub");
                CreateFlight = new RelayCommand(() =>
                {
                    Flights.Add(new Flight() {Destination = SelectedFlight.Destination });
                });

                UpdateFlight = new RelayCommand(() =>
                {
                    try
                    {
                        Flights.Update(SelectedFlight);
                    }
                    catch (Exception e)
                    {
                        errorMessage = e.Message;
                    }

                },
                () =>
                {
                    return SelectedFlight.ID != 0;
                });
               

                DeleteFlight = new RelayCommand(() =>
                {
                    Flights.Delete(SelectedFlight.ID);
                    selectedFlight = new Flight() { Destination = "" };
                },
                () =>
                {
                    return SelectedFlight.ID != 0;
                });

                selectedFlight = new Flight() { Destination = "" };
        

            }
        }
    }
}

