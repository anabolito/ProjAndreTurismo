﻿using ProjAndreTurismo.Controllers;
using ProjAndreTurismo.Models;

internal class Program
{
    public static void Main(string[] args)
    {
        City city = new();
        Address address = new();
        Address addressAux = new();
        Client client = new();
        Airfare airfare = new();
        Hotel hotel = new();
        Package package = new();
        int opc = 0;



        int options = 0;
        do
        {

            options = Menu();
            
            switch (options)
            {
                case 1:
                    while (opc != 5)
                    {
                        #region Cidade
                        Console.WriteLine("1-Inserir Cidade");
                        Console.WriteLine("2-Editar Cidade");
                        Console.WriteLine("3-Deletar Cidade");
                        Console.WriteLine("4-Mostrar Cidades");
                        Console.WriteLine("5-Sair");
                        Console.Write("O que deseja fazer?");
                        opc = int.Parse(Console.ReadLine());

                        switch (opc) //cidade
                        {
                            case 1: // inserir
                                Console.Clear();
                                Console.Write("Insira uma cidade: ");
                                string cityy = Console.ReadLine();
                                city.CityName = cityy;
                                new CityController().Insert(city);
                                Console.Clear();

                                break;

                            case 2: // editar
                                Console.Clear();
                                new CityController().FindAll().ForEach(Console.WriteLine);
                                Console.Write("Nome da cidade a ser editada:");
                                cityy = Console.ReadLine();

                                new CityController().Update(city);
                                Console.Clear();

                                break;

                            case 3:
                                Console.Clear();
                                new CityController().FindAll().ForEach(Console.WriteLine);
                                Console.Write("Nome da cidade a ser deletada:");

                                Console.Clear();

                                break;

                            case 4:
                                Console.Clear();
                                new CityController().FindAll().ForEach(Console.WriteLine);
                                Console.WriteLine("Pressione qualquer tecla para sair...");
                                Console.ReadKey();
                                Console.Clear();

                                break;

                            case 5:
                                #region Sáida do programa e tratativa 
                                System.Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Opção inválida!");
                                break;
                                #endregion


                        }
                    }
                    break;
                #endregion

                case 2:
                    #region Endereço
                    Console.Clear();
                    Console.Write("Rua: ");
                    string street = Console.ReadLine();

                    Console.Write("Número: ");
                    string number = Console.ReadLine();

                    Console.Write("Bairro: ");
                    string neighborhood = Console.ReadLine();

                    Console.Write("CEP: ");
                    string postalcode = Console.ReadLine();

                    Console.Write("Cidade: ");
                    string cityAddress = Console.ReadLine();


                    address.Street = street;
                    address.Number = number;
                    address.Neighborhood = neighborhood;
                    address.PostalCode = postalcode;
                    city.CityName = cityAddress;
                    address.City = city;

                    new AddressController().Insert(address);
                    break;
                #endregion

                case 3:
                    #region Cliente
                    Console.Clear();
                    Console.Write("Nome: ");
                    string name = Console.ReadLine();

                    Console.Write("Telefone: ");
                    string phone = Console.ReadLine();


                    new AddressController().FindAll().ForEach(x => Console.WriteLine(x));
                    Console.Write("Id Endereço : ");
                    int idAddress = int.Parse(Console.ReadLine());


                    client.Name = name;
                    client.Phone = phone;
                    address.Id = idAddress;
                    client.Address = address;

                    new ClientController().Insert(client);

                    Console.Clear();


                    break;
                #endregion

                case 4:
                    #region Passagem Aérea
                    Console.Clear();

                    new AddressController().FindAll().ForEach(x => Console.WriteLine(x));

                    Console.Write("Id do endereço de onde o avião partirá: ");
                    int origin = int.Parse(Console.ReadLine());

                    Console.Write("Id do endereço de pouso: ");
                    int destiny = int.Parse(Console.ReadLine());


                    new ClientController().FindAll().ForEach(x => Console.WriteLine(x));
                    Console.Write("Id Cliente : ");
                    int idCliente = int.Parse(Console.ReadLine());

                    address.Id = origin;
                    addressAux.Id = destiny;
                    airfare.Origin = address;
                    airfare.Destiny = addressAux;
                    client.Id = idCliente;
                    airfare.Client = client;

                    new AirfareController().Insert(airfare);

                    Console.Clear();


                    break;
                #endregion

                case 5:
                    #region Hotel
                    Console.Clear();

                    Console.Write("Nomen do hotel: ");
                    string nameHotel = Console.ReadLine();

                    Console.Write("Telefone: ");
                    double dailyPrice = double.Parse(Console.ReadLine());


                    new AddressController().FindAll().ForEach(x => Console.WriteLine(x));
                    Console.Write("Id Endereço : ");
                    int addressHotel = int.Parse(Console.ReadLine());


                    hotel.HotelName = nameHotel;
                    hotel.DailyPrice = dailyPrice;
                    address.Id = addressHotel;
                    hotel.Address = address;

                    new ClientController().Insert(client);

                    Console.Clear();


                    break;
                #endregion

                case 6:
                    #region Pacote de viagem
                    Console.Clear();

                    Console.Write("Preço do pacote: ");
                    double packagePrice = double.Parse(Console.ReadLine());

                    Console.Write("Nome do hotel: ");
                    string hotelName = Console.ReadLine();

                    new AirfareController().FindAll().ForEach(x => Console.WriteLine(x));

                    Console.Write("Id da passagem aérea: ");
                    int idAirfare = int.Parse(Console.ReadLine());

                    Console.Write("Nome do Cliente: ");
                    string clientName = Console.ReadLine();

                    package.PackagePrice = packagePrice;
                    hotel.HotelName = hotelName;
                    package.Hotel = hotel;
                    airfare.Id = idAirfare;
                    package.Airfare = airfare;
                    client.Name = clientName;
                    package.Client = client;

                    new PackageController().Insert(package);

                    Console.Clear();


                    break;
                #endregion


                case 7:
                    #region Sáida do programa e tratativa 
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
                    #endregion

            }

        } while (options != 7);


    }

    private static int Menu()
    {
        Console.WriteLine("Bem vindo(a)!");
        Console.WriteLine("1- Cidade");
        Console.WriteLine("2- Endereço");
        Console.WriteLine("3- Cliente");
        Console.WriteLine("4- Passagem Aérea");
        Console.WriteLine("5- Hotel");
        Console.WriteLine("6- Pacote de viagem");
        Console.WriteLine("7- Sair do Menu");
        Console.Write("Digite o número da função que deseja acessar: ");
        int option = int.Parse(Console.ReadLine());
        Console.Clear();
        return option;
    }
}



















