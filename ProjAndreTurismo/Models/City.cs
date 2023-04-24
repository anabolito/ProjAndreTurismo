using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Models
{
    public class City
    {
        #region Properties
        public int Id { get; set; }
        public string CityName { get; set; }

        //public DateTime Date { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return
                   $"\nCidade: {CityName} ";
        }
        #endregion
    }
}
