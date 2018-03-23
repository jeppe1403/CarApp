using CarApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarCatalogPage : ContentPage
	{
		public CarCatalogPage ()
		{
			InitializeComponent ();
            BindingContext = new CarCatalogViewModel(); //Kalder min viewmodel. For at skabe en MVVM (Model, View, ViewModel) struktur
        }
	}
}