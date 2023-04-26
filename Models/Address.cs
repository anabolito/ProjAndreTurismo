using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        public readonly static string INSERT = "Insert into Address (Street, Number, Neighborhood, PostalCode, IdCity)" +
                                "values (@Street, @Number, @Neighborhood, @PostalCode, @IdCity)";
        public readonly static string GETALL = "select * from Address ad, City c where ad.IdCity = c.Id";
        public readonly static string DELETE = "delete from Address where Id = @Id";
        public readonly static string UPDATE = "update Address set Street = @Street, Number = @Number , Neighborhood = @Neighborhood, PostalCode = @PostalCode, IdCity = @IdCity where Id = @Id";



        #region Properties
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string PostalCode { get; set; }
        public DateTime RegisterDate { get; set; }
        public City City { get; set; }
        #endregion

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }


    }
}
