using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp.Models
{
    public class SalesList //Hvilke properties et produkt der er tilføjet til Cart skal indeholde
    {
        public string CarName { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string ImageSource { get; set; }
    }
}
