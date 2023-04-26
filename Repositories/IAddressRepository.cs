using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IAddressRepository
    {
        bool Insert(Address address);
        bool Delete(Address address);
        bool Update(Address address);
        List<Address> GetAll();
    }
}
