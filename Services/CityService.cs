using Repositories;
using Models;

namespace Services
{
    public class CityService
    {
        private ICityRepository cityRepository;

        public CityService()
        {
            cityRepository = new CityRepository();
        }

        public City Insert(City city)
        {
            return cityRepository.Insert(city);
        }

        public bool Delete(City city)
        {
            return cityRepository.Delete(city);
        }

        public bool Update(City city)
        {
            return cityRepository.Update(city);
        }

        public List<City> GetAll()
        {
            return cityRepository.GetAll();
        }

        public City GetById(int id)
        {
            return cityRepository.GetById(id);
        }

    }
}
