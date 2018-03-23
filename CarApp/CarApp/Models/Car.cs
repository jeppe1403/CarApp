using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarApp.Models //Model med de properties som hver enkelt bil eller produkt indeholder.
{
    public class Car 
    {
        public int CarID { get; set; }
        public string CarModel { get; set; }
        public int YearOfModel { get; set; }
        public double Price { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
    }
}
