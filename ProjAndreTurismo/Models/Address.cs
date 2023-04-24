using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Models
{
    public class Address
    {
        #region Properties
        public int       Id            {get; set;}
        public string    Street        {get; set;}
        public string    Number        {get; set;}
        public string    Neighborhood  {get; set;}
        public string    PostalCode    {get; set;}
        public DateTime  RegisterDate  {get; set;}
        public City      City          {get; set;}
        #endregion


        #region Methods
        public override string ToString()
        {
            return 
                 $"\nLogradouro: {Street} " +
                 $"\nNúmero: {Number} " +
                 $"\nBairro: {Neighborhood} " +
                 $"\nCEP: {PostalCode}" +
                 $"\nCidade: {City} " +
                 $"\nData de cadastro: {RegisterDate}";
        }
        #endregion
    }
}
