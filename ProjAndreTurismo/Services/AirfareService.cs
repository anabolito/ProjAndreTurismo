using ProjAndreTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Services
{
    public class AirfareService
    {
        #region readonly
        static readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\ONEDRIVE\DOCUMENTOS\AndreTurism.MDF;";
        SqlConnection connection = new SqlConnection(strConn);

        #endregion

        public AirfareService()
        {
            var conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Airfare airfare)
        {

            string strInsert = "insert into Airfare (Origin, Destiny, Client, Price)" +
                "values  (@IdOrigin, @IdDestiny, @IdClient, @Price)";

            SqlCommand commandInsert = new SqlCommand(strInsert, connection);

            commandInsert.Parameters.Add(new SqlParameter("@IdOrigin", new AddressService().AddressInsert(airfare.Origin)));
            commandInsert.Parameters.Add(new SqlParameter("@IdDestiny",new AddressService().AddressInsert(airfare.Destiny)));
            commandInsert.Parameters.Add(new SqlParameter("@IdClient", new ClientService().ClientInsert(airfare.Client)));
            commandInsert.Parameters.Add(new SqlParameter("@Price", airfare.Price));


            commandInsert.ExecuteScalar();

            return true;

        }

        public List<Airfare> FindAll()
        {
            connection.Open();

            List<Airfare> airfares = new();

            StringBuilder sb = new StringBuilder();
            sb.Append(" select a.Id, ");
            sb.Append("        ad.Id IdOrigin, ");
            sb.Append("        ad.Id IdDestiny, ");
            sb.Append("        c.Id IdClient, ");
            sb.Append("        a.Price");
            sb.Append("  from  Airfare a, ");
            sb.Append("        Address ad,");
            sb.Append("        Client c,");

            sb.Append("  where a.IdOrigin = ad.Id");


            SqlCommand commandSelect = new(sb.ToString(), connection);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Airfare airfare = new();

                //airfare.Id = (int)dr["Id"];
                //airfare.Origin = (string)dr["Street"];
                //airfare.Destiny = (string)dr["Number"];
                //airfare.Price = (int)dr["Price"];
                //airfare.Price = (int)dr["Price"];

                airfares.Add(airfare);

            }
            connection.Close();

            return airfares;

        }


    }
}
