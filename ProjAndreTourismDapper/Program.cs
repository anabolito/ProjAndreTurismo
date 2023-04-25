using Controllers;
using Models;

internal class Program
{
    private static void Main(string[] args)
    {
        #region CRUD CITY
        var city = new City()
        {
            CityName = "teste",
            Id = 33 
        };

        //string returnInformation = (new CityController().Insert(city) ? "Inserido" : "Erro");
        //Console.WriteLine(returnInformation);

        //string returnInformation = (new CityController().Update(city) ? "Editado" : "Erro");
        //Console.WriteLine(returnInformation);

        string returnInformation = (new CityController().Delete(city) ? "Deletado" : "Erro");
        Console.WriteLine(returnInformation);

        //new CityController().GetAll().ForEach(x => Console.WriteLine(x));
        #endregion
    }
}