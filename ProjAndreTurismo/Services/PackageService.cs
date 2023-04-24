using ProjAndreTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Services
{
    public class PackageService
    {
        #region readonly
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\ONEDRIVE\DOCUMENTOS\AndreTurism.MDF;";
        readonly SqlConnection conn;
        #endregion

        public PackageService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Package package)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into Package (Hotel, Airfare, DateRegister, PackagePrice, Client)" +
                    "values  (@idHotel, @idAirfare, @DateRegister, @PackagePrice, @idClient)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@idHotel",  new HotelService().Insert(package.Hotel)));
                commandInsert.Parameters.Add(new SqlParameter("@idAirfare",new AirfareService().Insert(package.Airfare)));
                commandInsert.Parameters.Add(new SqlParameter("@idClient", new ClientService().ClientInsert(package.Client)));
                commandInsert.Parameters.Add(new SqlParameter("@DateRegister", package.DateRegister));
                commandInsert.Parameters.Add(new SqlParameter("@PackagePrice", package.PackagePrice));


                commandInsert.ExecuteScalar();

                status = true;
            }
            catch (Exception e)
            {
                status = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        
        public List<Package> FindAll()
        {
            List<Package> packages = new();

            StringBuilder sb = new StringBuilder();
           
            #region Appends
            sb.Append("select p.Id IdPacote,");
            sb.Append("p.RegisterDate DataRegPacote,");
            sb.Append("p.PackagePrice PrecoPacote,");
            sb.Append("h.HotelName Hotel,");
            sb.Append("h.Dailyprice Diaria,");
            sb.Append("h.RegisterDate DataRegistroHotel,");
            sb.Append("ad.Street RuaHotel,");
            sb.Append("ad.Number NumeroHotel,");
            sb.Append("ad.Neighborhood BairroHotel,");
            sb.Append("ad.PostalCode CepHotel,");
            sb.Append("ad.Complety ComplementoHotel,");
            sb.Append("ad.RegisterDate DataRegistroEndereçoHotel,");
            sb.Append("c.CityName CidadeHotel,");
            sb.Append("a.Price PrecoPassagem,");
            sb.Append("ad.Street RuaOrigem,");
            sb.Append("ad.Number NumeroOrigem,");
            sb.Append("ad.Neighborhood BairroOrigem,");
            sb.Append("ad.PostalCode CepOrigem,");
            sb.Append("ad.Complety ComplementoOrigem,");
            sb.Append("ad.RegisterDate DataRegistroEndereçoOrigem,");
            sb.Append("c.CityName CidadeOrigem,");
            sb.Append("ad.Street RuaDestino,");
            sb.Append("ad.Number NumeroDestino,");
            sb.Append("ad.Neighborhood BairroDestino,");
            sb.Append("ad.PostalCode CepDestino,");
            sb.Append("ad.Complety ComplementoDestino,");
            sb.Append("ad.RegisterDate DataRegistroEndereçoDestino,");
            sb.Append("c.CityName CidadeDestino");
            sb.Append("from Package p,");
            sb.Append("Hotel h,");
            sb.Append("Airfare a,");
            sb.Append("Client cl,");
            sb.Append("Address ad,");
            sb.Append("City c");
            sb.Append("  where  p.idHotel = h.Id");
            sb.Append("and p.idAirfare = a.Id");
            sb.Append("and p.idClient = c.Id");
            sb.Append("and h.idAddress = ad.Id");
            sb.Append("and ad.IdCity = c.Id");
            sb.Append("and a.IdOrigin = ad.Id");
            sb.Append("and a.IdDestiny = ad.Id");
            #endregion


            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Package package = new();

                package.Id = (int)dr["Id"];
                package.DateRegister = (DateTime)dr["RegisterDate"];
                package.PackagePrice = (double)dr["PackagePrice"];
                package.Hotel = new Hotel() { HotelName = (string)dr["HotelName"], RegisterDate = (DateTime)dr["RegisterDate"], DailyPrice = (double)dr["DailyPrice"] };  // COMO COLOCO O ADDRESS AQUI????????????
                package.Airfare = new Airfare() { Price = (double)dr["Price"] }; // como colocar os endereços de origem, destino e cliente??
                package.Client = new Client() { Name = (string)dr["Name"], Phone = (string)dr["Phone"], RegisterDate = (DateTime)dr["RegisterDate"],   }; //como colocar o endereço?

                packages.Add(package);

            }
            return packages;

        }
    }
}
