using CarApp.ViewModels;
using CarApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CarApp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            Master.Instance = new CarMasterDetailPage(); //Laver en CarMasterDetailPage og sætter den som MainPage.
            MainPage = Master.Instance;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
