using ProjAndreTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Services
{
    public class HotelService
    {
        #region readonly
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\ONEDRIVE\DOCUMENTOS\AndreTurism.MDF;";
        readonly SqlConnection conn;
        #endregion

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Hotel hotel)
        {

            string strInsert = "insert into Hotel (HotelName, DailyPrice, Address, RegisterDate)" +
                "values  (@HotelName, @DailyPrice, @IdAddress, @RegisterDate)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@HotelName", hotel.HotelName));
            commandInsert.Parameters.Add(new SqlParameter("@DailyPrice", hotel.DailyPrice));
            commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", hotel.RegisterDate));
            commandInsert.Parameters.Add(new SqlParameter("@idAddress", new AddressService().AddressInsert(hotel.Address)));


            commandInsert.ExecuteScalar();

            return true;

        }
    }
}
