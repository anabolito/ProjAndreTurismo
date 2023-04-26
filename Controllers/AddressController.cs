using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace Controllers
{
    public class AddressController
    {
        private AddressService addressService;
        private CityService cityService;

        public AddressController()
        {
            addressService = new AddressService();
            cityService = new CityService();
        }

        public bool Insert(Address address)
        {
            City city = new();
            if (address.City.Id != 0)
                city = cityService.GetById(address.City.Id);
            else
                city = cityService.Insert(address.City);
            address.City = city;

            return addressService.Insert(address);
        }
        public bool Delete(Address address)
        {
            return addressService.Delete(address);
        }
        public bool Update(Address address)
        {
            return addressService.Update(address);
        }

        public List<Address> GetAll()
        {
            return addressService.GetAll();
        }
    }
}
