using ProyectoTest.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTest.Dummy
{
    public class ClientDummy
    {

        public ClientDummy()
        {
        }

        public ClientListDto listaDummyClient() {
            
            ClientListDto clientListDto = new ClientListDto();
            ClientDto clientDto = new ClientDto
            {
                IdDto = 1,
                NameDto = "Jumbo"
            };
            clientListDto.ClientsList.Add(clientDto);

            return clientListDto;
        }

        public ClientDto idClientByEntities(int id, int idEntities)
        {
            

            ClientDto clientDto = new ClientDto
            {
                IdDto = 1,
                NameDto = "Jumbo"
            };

            return clientDto;
        }

    }
}
