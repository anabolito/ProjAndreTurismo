using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Models
{
    public class Hotel
    {
        #region Properties
        public int      Id            {get; set;}
        public string   HotelName     {get; set;}
        public Address  Address       {get; set;}
        public DateTime RegisterDate  {get; set;}
        public double   DailyPrice    {get; set;}
        #endregion

        #region Methods
        public override string ToString()
        {
            return 
                   $"\nHotel: {HotelName} " +
                   $"\nEndereço: {Address} " +
                   $"\nBairro: {RegisterDate} " +
                   $"\nCEP: {DailyPrice}";
        }
        #endregion
    }
}
