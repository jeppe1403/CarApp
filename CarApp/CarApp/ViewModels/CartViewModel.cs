using CarApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CarApp.ViewModels
{
    public class CartViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SalesList> productslist;
        public ObservableCollection<SalesList> ProductList
        {
            get { return productslist; }
            set
            {

                productslist = value;
            }
        }

        public CartViewModel()
        {
            ProductList = new ObservableCollection<SalesList>(); //Laver en liste over produkter som er i kurven.
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
