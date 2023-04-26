using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;


namespace Models
{
    public class City
    {
        public readonly static string INSERT = "Insert into City (CityName)" +
                                        "values (@CityName); select cast(scope_identity() as int)";
        public readonly static string GETALL = "select Id, CityName from City";
        public readonly static string GETBYID = "select Id, CityName from City where Id = @Id";
        public readonly static string DELETE = "delete from City where City.Id = @Id";
        public readonly static string UPDATE = "update City set CityName = @CityName where Id = @Id";

        #region Properties
        public int Id { get; set; }
        public string CityName { get; set; }
        #endregion

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

    }
}
