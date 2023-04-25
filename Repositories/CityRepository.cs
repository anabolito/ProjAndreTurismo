using Dapper;
using Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Repositories
{
    public class CityRepository : ICityRepository
    {
        private string Conn { get; set; }

        public CityRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public bool Insert(City city)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute(City.INSERT, city);
                status = true;
                db.Close();
            }
            return status;
        }

        public bool Delete(City city)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Execute(City.DELETE, city);
                status = true;

            }
            return status;
        }

        public bool Update(City city)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Execute(City.UPDATE, city);
                status = true;
            }
            return status;
        }

        public List<City> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                var cities = db.Query<City>(City.GETALL);
                return (List<City>)cities;
            }
        }

       
    }
}
