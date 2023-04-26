using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;
using System.Configuration;
using System.IO;


namespace Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private string Conn { get; set; }

        public AddressRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public bool Insert(Address address)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute(Address.INSERT, new {@Street = address.Street, @Number = address.Number, @Neighborhood = address.Neighborhood, @PostalCode = address.PostalCode, @IdCity = address.City.Id });
                status = true;
                db.Close();
            }
            return status;
        }

        public bool Delete(Address address)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Execute(Address.DELETE, address);
                status = true;

            }
            return status;
        }

        public bool Update(Address address)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Execute(Address.UPDATE, new { @Id = address.Id, @Street = address.Street, @Number = address.Number, @Neighborhood = address.Neighborhood, @PostalCode = address.PostalCode, @IdCity = address.City.Id });
                status = true;
            }
            return status;
        }

        public List<Address> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                var addresses = db.Query<Address>(Address.GETALL);
                return (List<Address>)addresses;
            }
        }
    }
}
