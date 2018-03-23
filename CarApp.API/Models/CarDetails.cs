using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CarApp.API.Models
{
    public class CarDetails //Model som indeholder de properties som vores Car model i applikationen indeholder
    {
        public int CarID { get; set; }
        public string CarModel { get; set; }
        public int YearOfModel { get; set; }
        public double Price { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
    }

    public interface ICarRepository
    {
        IEnumerable<CarDetails> SeeAllCars();
    }

    public class CarRepository : ICarRepository
    {
        private string xmlFilename = null;
        private XDocument xmlDocument = null;

        public CarRepository() //Henter Cars.xml og loader det ind som et xml dokument
        {
            try
            {
                xmlFilename = HttpContext.Current.Server.MapPath("~/app_data/Cars.xml");
                xmlDocument = XDocument.Load(xmlFilename);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CarDetails> SeeAllCars() //Konverter xml fil til et CarDetails objekt. På den måde kan objekt sendes til applikation og modtages som json, med en GET request.
        {
            try
            {
                return (
                    from car in xmlDocument.Elements("catalog").Elements("car")
                    orderby car.Attribute("id").Value ascending
                    select new CarDetails //Sætter de forskellige tags i XML fil = properties i CarDetails
                    {
                        CarID = Convert.ToInt32(car.Attribute("id").Value),
                        CarModel = car.Element("carmodel").Value,
                        YearOfModel = Convert.ToInt32(car.Element("yearofmodel").Value),
                        Price = Convert.ToDouble(car.Element("price").Value),
                        ImageSource = car.Element("imagesource").Value,
                        Description = car.Element("description").Value
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
