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
    public class PassengerEditorWindowViewModel : ObservableRecipient
    {
        public RestCollection<Passenger> Passengers { get; set; }

        private Passenger selectedPassenger;
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public Passenger SelectedPassenger
        {
            get { return selectedPassenger; }
            set
            {
                if (value != null)
                {
                    selectedPassenger = new Passenger()
                    {
                        Name = value.Name,
                        Age = value.Age,
                        ID = value.ID
                    };
                    OnPropertyChanged();
                    (DeletePassenger as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        public ICommand CreatePassenger { get; set; }
        public ICommand DeletePassenger { get; set; }
        public ICommand UpdatePassenger { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public PassengerEditorWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Passengers = new RestCollection<Passenger>("http://localhost:5000/", "Passenger", "hub");
                CreatePassenger = new RelayCommand(() =>
                {
                    Passengers.Add(new Passenger() { Name = SelectedPassenger.Name });
                });

                UpdatePassenger = new RelayCommand(() =>
                {

                    try
                    {
                        Passengers.Update(SelectedPassenger);
                    }
                    catch (Exception e)
                    {
                        errorMessage = e.Message;
                    }

                });
                


                DeletePassenger = new RelayCommand(() =>
                {
                    Passengers.Delete(SelectedPassenger.ID);
                    
                },
                () =>
                {
                    return SelectedPassenger.ID != 0;
                });

                selectedPassenger = new Passenger();

            }
        }
    }
}

