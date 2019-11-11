using ProyectoTest.Dto;
/**
 * Sebastian Gonzalez
 * */
namespace ProyectoTest.Service
{
    public interface IClientService
    {
        ClientListDto listClientByEmail(string email);

        ClientDto clientByEntities(int id, int idEntities);
    }
}
