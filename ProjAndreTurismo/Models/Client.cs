using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Models
{
    public class Client
    {
        #region Properties
        public int       Id             {get; set;}
        public string    Name           {get; set;}
        public string    Phone          {get; set;}
        public DateTime  RegisterDate   {get; set;}
        public Address   Address        {get; set;}
        #endregion

        #region Methods
        public override string ToString()
        {
            return 
                   $"\nNome: {Name} " +
                   $"\nTelefone: {Phone} " +
                   $"\nEndereço: {Address} " +
                   $"\nData de cadastro: {RegisterDate}";
        }
        #endregion
    }
}
