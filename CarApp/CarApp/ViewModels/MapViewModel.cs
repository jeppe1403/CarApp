using CarApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace CarApp.ViewModels
{
    public class MapViewModel
    {
        public MapViewModel()
        {
            var CarMap = new Map(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(10)));
            var position = new Position(10.125111, 56.113631); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Car Store",
                Address = "Hasselager Alle 2"
            };
            CarMap.Pins.Add(pin);
        }
    }
}
