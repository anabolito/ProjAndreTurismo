using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Repositories
{
    public interface ICityRepository
    {
        City Insert(City city);
        bool Delete(City city);
        bool Update(City city); 
        City GetById(int id);
        List<City> GetAll();
    }

}
