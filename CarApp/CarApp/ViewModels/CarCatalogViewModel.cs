using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarApp.Models;
using CarApp.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CarApp.ViewModels
{
    public class CarCatalogViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Car> products;

        public ObservableCollection<Car> Products //Laver en observablecollection. En liste over produkter. Har Car modellen som input, så de produkter der ligger i collection indeholder de properties der er i Car modellen.
        {
            get { return products; }
            set
            {

                products = value;
            }
        }
        public CarCatalogViewModel() //Min Constructor. Koden i min constructor bliver kørt med det samme at min viewmodel bliver kaldt, hvilket sker når jeg kører mit view.
        {
            Products = new ObservableCollection<Car>();
            LoadData(); //Kalder metode som henter produkter ud
        }

        private Car selectedProduct;

        public Car SelectedProduct //Kalder metoden OpenProduct hvor value er det produkt bruger har selected i view.
        {
            get { return selectedProduct; }
            set { selectedProduct = value; NotifyPropertyChanged("selectedProduct"); OpenProduct(value); }
        }

        private void OpenProduct(Car car) //Modtager et produkt i parameter
        {
            if (car == null)
                return;
            var page = new CarDetailsPage(); //Kalder en CarDetailsPage som skal vise detaljer på produkt.
            page.BindingContext = new CarDetailsViewModel(car); //View skal bruge CarDetailsViewModel, og den får car som parameter CarDetailsViewModel kan arbejde med det produkt der er sendt.
            Master.Instance.Detail = new NavigationPage(page); //Sætter den side der vises i applikationen til page som er CarDetailsPage.
        }

        const string apiUrl = @"http://10.0.2.2:52800/Cars/"; //url til xml fil. 10.0.2.2 er en ip adresse som peger fra emulatoren på loopbackadressen på maskinen.

        public bool IsDataLoaded //Sikre sig at der ikke hentes data efter data er blevet indlæst.
        {
            get;
            private set;
        }

        public async void LoadData()
        {
            if (IsDataLoaded == false)
            {
                Products.Clear();
                var httpClient = new HttpClient(); 
                var result = await httpClient.GetAsync(new Uri(apiUrl)); //laver en Get request til min Web API, og giver url til api. 
                var jsonfile = result.Content.ReadAsStringAsync().Result; //henter content på siden. Kommer ud i en lang string, og filen er lavet i json.
                ConvertData(jsonfile);
            }
        }

        private void ConvertData(string jsonfile) //Konverterer jsonfil om til objekter som kan ligges i Products
        {
            try
            {
                if (jsonfile != null)
                {
                    var cars = JsonConvert.DeserializeObject<Car[]>(jsonfile); //Konventer json string om til bestemt .Net type, i det her tilfælde vores Car Model.
                    foreach (Car car in cars) //Efter at have konverteret filen tilføjes hvert enkelt produkt til Products og de modtagene parametre sættes = properties i Car Modellen.
                    {
                        Products.Add(new Car() 
                        {
                            CarID = car.CarID,
                            CarModel = car.CarModel,
                            Price = car.Price,
                            Description = car.Description,
                            ImageSource = car.ImageSource,
                            YearOfModel = car.YearOfModel
                        });
                    }
                    this.IsDataLoaded = true;
                }
            }
            catch (Exception ex) //Exception i tilfælde af der ikke hentes data fra Web API, viser et produkt som fortæller der er en fejl.
            {
                Products.Add(new Car()
                {
                    CarID = 100,
                    CarModel = "An Error Occurred"
                });
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
