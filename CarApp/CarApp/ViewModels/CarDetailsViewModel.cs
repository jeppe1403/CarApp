using CarApp.Models;
using CarApp.Views;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarApp.ViewModels
{
    public class CarDetailsViewModel : INotifyPropertyChanged
    {
        private Car car;
        
        public CarDetailsViewModel(Car car) //Modtager Car som er sendt fra CarCatalog
        {
            this.car = car; //Sætter parameter = lokal instance
            AddProductToCartCommand = new Command(AddProductToCart);
        }
        //sætter properties fra parameter = samme properties i lokal instance. 
        public int CarID { get { return car.CarID; } set { car.CarID = value; } }
        public string CarModel { get { return car.CarModel; } set { car.CarModel = value; } }
        public string ImageSource { get { return car.ImageSource; } set { car.ImageSource = value; } }
        public string Description { get { return car.Description; } set { car.Description = value; } }
        public double Price { get { return car.Price; } set { car.Price = value; } }
        public int YearOfModel { get { return car.YearOfModel; } set { car.YearOfModel = value; } }

        public ICommand AddProductToCartCommand { get; private set; }

        private CartViewModel viewModel;

        private void AddProductToCart() //Laver en ny produktordrer og ligges i SalesList observablecolletion.
        {
            if (viewModel == null) 
            {
                viewModel = new CartViewModel();
                var page = new CartPage();
                page.BindingContext = viewModel;
                viewModel.ProductList.Add(new SalesList { CarName = CarModel, Count = 1, ImageSource = ImageSource, Price = Price });
                Application.Current.MainPage.DisplayAlert("Congrats", "You have added " + car.CarModel + " to Cart", "OK"); //Giver en alert til bruger om at produkt er added til Cart.
                Master.Instance.Detail = new NavigationPage(page);
            }
            else
            {
                viewModel.ProductList.Add(new SalesList { CarName = CarModel, Count = 1, ImageSource = ImageSource, Price = Price });
                Application.Current.MainPage.DisplayAlert("Congrats", "You have added " + car.CarModel + " to Cart", "OK"); 
                Master.Instance.Detail = new NavigationPage(new CartPage());
            }
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