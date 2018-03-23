using CarApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarApp.API.Controllers
{
    [Route("cars")] //Sætter sti på Web API hvor fil befinder sig
    public class CarsController : ApiController
    {
        private CarRepository repository = null;
        
        public CarsController() //Laver et Repository på Web API'et som viser vores XML Dokument.
        {
            repository = new CarRepository();
        }
        
        [HttpGet]
        public HttpResponseMessage Get()
        {
            IEnumerable<CarDetails> cars = repository.SeeAllCars(); //Tager XML fil fra repository, konverter den til objekter og tilføjer dem til en IEnumable liste.
            if (cars != null)
            {
                return Request.CreateResponse<IEnumerable<CarDetails>>(HttpStatusCode.OK, cars); //Sender et OK tilbage sammen med en IEnumerable liste som indeholder vores produkter.
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
