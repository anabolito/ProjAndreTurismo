using ProjAndreTurismo.Models;
using ProjAndreTurismo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Controllers
{
    public class AirfareController
    {
        public bool Insert(Airfare airfare)
        {
            return new AirfareService().Insert(airfare);
        }

        public List<Airfare> FindAll()
        {

            return new AirfareService().FindAll();
        }


    }
}
