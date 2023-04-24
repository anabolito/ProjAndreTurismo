using ProjAndreTurismo.Models;
using ProjAndreTurismo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Controllers
{
    public class CityController
    {
        public int Insert(City city)
        {
            return new CityService().Insert(city);
        }

    }
}
