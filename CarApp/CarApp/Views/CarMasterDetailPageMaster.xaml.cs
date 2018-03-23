﻿using CarApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public CarMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new CarMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        
    }
}