using ProjAndreTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Services
{
    public class CityService
    {
        #region readonly
        static readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\ONEDRIVE\DOCUMENTOS\ANDRETURISM.MDF;";
        //readonly SqlConnection conn;
        #endregion
        SqlConnection connection = new SqlConnection(strConn);

        public CityService()
        {
            var conn = new SqlConnection(strConn);
            conn.Open();
        }

        public int Insert(City city)
        {
            connection.Open();

            string strinsert = "insert into City (CityName) values (@CityName);" + "select cast(scope_identity() as int)";

            SqlCommand sqlInsert = new SqlCommand(strinsert, connection);

            sqlInsert.Parameters.Add(new SqlParameter("@CityName" , city.CityName));

            var aux = (int)sqlInsert.ExecuteScalar();

            connection.Close();

            return aux;
        }

        public List<City> FindAll()
        {
            connection.Open();
            List<City> cities = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select  c.Id,");
            sb.Append("		c.CityName");
            sb.Append("		from City c");

            SqlCommand commandSelect = new(sb.ToString(), connection);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                City city = new();

                city.Id = (int)dr["Id"];
                city.CityName = (string)dr["CityName"];

                cities.Add(city);

            }
            connection.Close();
            return cities;
        }

        public int Update(City city)
        {
            string update = "update City set NameCity = @NameCity where Id = @id";
            SqlCommand commandUpdate = new SqlCommand(update, connection);
            commandUpdate.Parameters.Add(new SqlParameter("@Id", city.Id));
            commandUpdate.Parameters.Add(new SqlParameter("@CityName", city.CityName));

            return commandUpdate.ExecuteNonQuery();
        }


        public int Delete(int id)
        {
            string _delete = "delete from City where Id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, connection);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));

            return (int)commandDelete.ExecuteNonQuery();
        }
    }
}
