using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Models
{
    public class Airfare
    {
        #region Properties
        public int      Id       { get; set; }
        public Address  Origin   { get; set; }
        public Address  Destiny  { get; set; }
        public Client   Client   { get; set; }
        public double   Price    { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"ID:{Id} " +
                 $"\nOrigem: {Origin} " +
                 $"\nDestino: {Destiny} " +
                 $"\nCliente: {Client}" +
                 $"\nValor da passagem: {Price} ";
        }
        #endregion
    }



}
