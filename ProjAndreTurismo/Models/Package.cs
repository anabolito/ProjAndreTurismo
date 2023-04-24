using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjAndreTurismo.Models
{
    public class Package
    {
        #region Properties
        public int       Id             {get; set;}
        public double    PackagePrice   {get; set;}
        public DateTime  DateRegister   {get; set;}
        public Hotel     Hotel          {get; set;}
        public Airfare   Airfare        {get; set;}
        public Client    Client         {get; set;}
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"ID:{Id} " +
                 $"\nHotel: {Hotel} " +
                 $"\nPassagem aérea: {Airfare} " +
                 $"\nData: {DateRegister} " +
                 $"\nValor total do pacote: {PackagePrice} " +
                 $"\nCliente: {Client}";
        }
        #endregion
    }
}
