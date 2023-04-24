using ProjAndreTurismo.Models;
using ProjAndreTurismo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreTurismo.Controllers
{
    internal class ClientController
    {
        public Client Insert(Client client)
        {
            return new ClientService().ClientInsert(client);
        }

        public List<Client> FindAll()
        {

            return new ClientService().FindAll();
        }

    }
}
