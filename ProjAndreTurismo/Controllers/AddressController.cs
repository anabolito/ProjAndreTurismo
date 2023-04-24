using ProjAndreTurismo.Models;
using ProjAndreTurismo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Controllers
{
    public class AddressController
    {
        //public bool Insert(Address address)
        //{
        //    return new AddressService().Insert(address);
        //}

        public Address Insert(Address address)
        {
            return new AddressService().AddressInsert(address);
        }

        public List<Address> FindAll()
        {

            return new AddressService().FindAll();
        }
    }
}
