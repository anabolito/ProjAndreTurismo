using ProjAndreTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Services
{

    public class ClientService
    {
        #region readonly
        static readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\ONEDRIVE\DOCUMENTOS\AndreTurism.MDF;";
        SqlConnection connection = new SqlConnection(strConn);
        #endregion

        public ClientService()
        {
            var conn = new SqlConnection(strConn);
            conn.Open();
        }

        public Client ClientInsert(Client client)
        {
            connection.Open();

            string strInsert = "insert into Client (Name, Phone, Address, RegisterDate)" +
                    "values  (@Name, @Phone, @IdAddress, @RegisterDate)" + "select cast(scope_identity() as int)"; ;

                SqlCommand commandInsert = new SqlCommand(strInsert, connection);

                commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Phone", client.Phone));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", client.RegisterDate = DateTime.Now));
                commandInsert.Parameters.Add(new SqlParameter("@idAddress", new AddressService().AddressInsert(client.Address)));


                commandInsert.ExecuteScalar();

            connection.Close();

            return client;
            
        }

        public List<Client> FindAll()
        {
            connection.Open();

            List<Client> clients = new();

            StringBuilder sb = new StringBuilder();
            sb.Append(" select c.Id, ");
            sb.Append("        c.Name, ");
            sb.Append("        c.Phone, ");
            sb.Append("        a.RefisterDate, ");
            sb.Append("        c.RegisterDate");
            sb.Append("  from  Client c, ");
            sb.Append("        Address a");
            sb.Append("  where c.IdAddress = a.Id");


            SqlCommand commandSelect = new(sb.ToString(), connection);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Client client = new();

                client.Id = (int)dr["Id"];
                client.Name = (string)dr["Street"];
                client.Phone = (string)dr["Number"];
                client.RegisterDate = (DateTime)dr["RegisterDate"];
                client.Address = new Address() { Street = (string)dr["Street"], Number = (string)dr["Number"], Neighborhood = (string)dr["Neighborhood"], PostalCode = (string)dr["PostalCode"], City = (City)dr["IdCity"] };

                clients.Add(client);

            }
            connection.Close();

            return clients;

        }




    }

}
