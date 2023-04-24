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
    }
}
