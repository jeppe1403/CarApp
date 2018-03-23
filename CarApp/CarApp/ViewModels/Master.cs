using CarApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp.ViewModels
{
    public static class Master //Klasse der er lavet for at kunne ændre Detail (Hvilket view der vises) i vores viewmodel.
    {
        public static CarMasterDetailPage Instance { get; set; }
    }
}
