using Models;
using Services;

namespace Controllers
{
    public class CityController
    {
        private CityService cityService;

        public CityController()
        {
            cityService = new CityService();
        }

        public bool Insert(City city)
        {
            return cityService.Insert(city);
        }
        public bool Delete(City city)
        {
            return cityService.Delete(city);
        }
        public bool Update(City city)
        {
            return cityService.Update(city);
        }

        public List<City> GetAll()
        {
            return cityService.GetAll();
        }
    }
}
