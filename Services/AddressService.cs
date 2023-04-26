using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class AddressService
    {
        private IAddressRepository addressRepository;

        public AddressService()
        {
            addressRepository = new AddressRepository();
        }

        public bool Insert(Address address)
        {
            return addressRepository.Insert(address);
        }

        public bool Delete(Address address)
        {
            return addressRepository.Delete(address);
        }

        public bool Update(Address address)
        {
            return addressRepository.Update(address);
        }

        public List<Address> GetAll()
        {
            return addressRepository.GetAll();
        }
    }
}
