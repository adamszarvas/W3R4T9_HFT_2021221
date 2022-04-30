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
    public class AirlineEditorWindowViewModel : ObservableRecipient
    {
        public RestCollection<Airline> Airlines { get; set; }

        private Airline selectedAirline;
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public Airline SelectedAirline
        {
            get { return selectedAirline; }
            set
            {
                if (value != null)
                {
                    selectedAirline = new Airline()
                    {
                        Name = value.Name,
                        Region = value.Region,
                        PassengersYearly = value.PassengersYearly,
                        ID = value.ID

                    };
                    OnPropertyChanged();
                    (DeleteAirline as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateAirline { get; set; }
        public ICommand DeleteAirline { get; set; }
        public ICommand UpdateAirline { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AirlineEditorWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Airlines = new RestCollection<Airline>("http://localhost:5000/", "Airline", "hub");
                CreateAirline = new RelayCommand(() =>
                {
                    Airlines.Add(new Airline() { Name = SelectedAirline.Name });
                });

                UpdateAirline = new RelayCommand(() =>
                 {
                     Airlines.Update(SelectedAirline);
                 },
                  () =>
                  {
                      return (SelectedAirline != null);
                  });

                DeleteAirline = new RelayCommand(() =>
                {
                    Airlines.Delete(SelectedAirline.ID);
                },
                () =>
                {
                    return SelectedAirline.ID != 0;
                });


                selectedAirline = new Airline() {Name = "" };

            }
        }
    }
}
