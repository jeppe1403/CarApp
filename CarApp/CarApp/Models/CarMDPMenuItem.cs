using CarApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Models
{

    public class CarMDPMenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; } //Titel på view. Defineres i hvert view ved at skrive Title = "" i toppen. 

        public Type TargetType { get; set; } //Hvilket view skal siden vise.
    }
}