using ProjAndreTurismo.Models;
using ProjAndreTurismo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Controllers
{

    public class PackageController
    {
        public bool Insert(Package package)
        {
            return new PackageService().Insert(package);
        }
        public List<Package> FindAll()
        {

            return new PackageService().FindAll();
        }
    }
}

