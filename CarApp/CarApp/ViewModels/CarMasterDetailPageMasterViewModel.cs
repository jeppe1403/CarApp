using CarApp.Models;
using CarApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarApp.ViewModels
{
    public class CarMasterDetailPageMasterViewModel : INotifyPropertyChanged //Gør brug af INotifyPropertyChanged så at koden registrer at bruger trykker på et menuitem.
    {
        public ObservableCollection<CarMDPMenuItem> MenuItems { get; set; }

        public CarMasterDetailPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<CarMDPMenuItem>(new[] //Tilføjer statiske menuitems som kalder hvert deres view
            {
                    new CarMDPMenuItem { Id = 0, Title = "Car Catalog", TargetType = typeof(CarCatalogPage) },
                    new CarMDPMenuItem { Id = 1, Title = "Physical location", TargetType = typeof(MapPage) },
                });
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
