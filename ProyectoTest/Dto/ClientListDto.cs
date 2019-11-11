using System;
using System.Collections.Generic;
/**
 * Sebastian Gonzalez
 * */
namespace ProyectoTest.Dto
{
    [Serializable]
    public class ClientListDto
    {
        private List<ClientDto> _clientsList;

        public ClientListDto() {
            _clientsList = new List<ClientDto>();
        }
        public List<ClientDto> ClientsList { get => _clientsList; set => _clientsList = value; }
    }
}
