using ProjAndreTurismo.Controllers;
using ProjAndreTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Services
{
    public class AddressService
    {
        #region readonly
        static readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\ONEDRIVE\DOCUMENTOS\AndreTurism.MDF;";
       
        #endregion
        SqlConnection connection = new SqlConnection(strConn);

        public AddressService()
        {
            var conn = new SqlConnection(strConn);
            conn.Open();
        }

       
        public Address AddressInsert(Address address) 
        {
            connection.Open();
            string strInsert = "insert into Address (Street , Number, Neighborhood, PostalCode, RegisterDate, IdCity)" +
                "values (@Street , @Number, @Neighborhood, @PostalCode, @RegisterDate, @IdCity);" +
                "select cast(scope_identity() as int)";

            SqlCommand sqlInsert = new SqlCommand(strInsert, connection);

            sqlInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
            sqlInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
            sqlInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
            sqlInsert.Parameters.Add(new SqlParameter("@PostalCode", address.PostalCode));
            sqlInsert.Parameters.Add(new SqlParameter("@RegisterDate", address.RegisterDate = DateTime.Now));
            sqlInsert.Parameters.Add(new SqlParameter("@IdCity", new CityService().Insert(address.City)));

            sqlInsert.ExecuteScalar();
            connection.Close();
            return address;

        }


        public List<Address> FindAll()
        {
            connection.Open();

            List<Address> addresses = new();

            StringBuilder sb = new StringBuilder();
            sb.Append(" select a.Id, ");
            sb.Append("        a.Name, ");
            sb.Append("        a.Description, ");
            sb.Append("        a.NumberofPassagers, ");
            sb.Append("        e.Description Engine");
            sb.Append("  from  Adress a, ");
            sb.Append("        City c");
            sb.Append("  where a.IdCity = c.Id");


            SqlCommand commandSelect = new(sb.ToString(), connection);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Address address = new();

                address.Id = (int)dr["Id"];
                address.Street = (string)dr["Street"];
                address.Number = (string)dr["Number"];
                address.Neighborhood = (string)dr["Neighborhood"];
                address.PostalCode = (string)dr["PostalCode"];
                address.RegisterDate = (DateTime)dr["RegisterDate"];
                address.City = new City() { CityName = (string)dr["CityName"] };

                addresses.Add(address);

            }
            connection.Close();

            return addresses;

        }

    }
}
