
using ProyectoTest.Dto;
using ProyectoTest.Dummy;
using ProyectoTest.ExceptionError;
using ProyectoTest.Service;
using System;
/**
* Sebastian Gonzalez
* */
namespace ProyectoTest.Imp
{
    public class ImpClient : IClientService
    {
        private ClientDummy objClientDummy = new ClientDummy();

        

        /**
         * Injeccion de conexion a db y uso con linq
         * 
        //se enlaza el context
        private readonly GenericContext _genericContext;

        public ImpClient(GenericContext genericContext,IConfiguration configuration) {
            _genericContext = genericContext;
            Configuration = configuration;
        }

            //Invocacion del properties settings
            private IConfiguration Configuration { get; }
       */
        public ClientListDto listClientByEmail(string email)
        {
            ClientListDto clientListDto = new ClientListDto();
            try
            {
                clientListDto = objClientDummy.listaDummyClient();
            }
            catch (ExceptionNotFound exception) {
                Console.WriteLine(exception.Message, exception);
                throw new ExceptionNotFound(exception.Message);
            }
            return clientListDto;
        }

        public ClientDto clientByEntities(int id, int idEntities)
        {
            ClientDto clientDto = new ClientDto();
            try
            { 

                clientDto = objClientDummy.idClientByEntities(id,idEntities);
            }
            catch (ExceptionNotFound exception)
            {
                Console.WriteLine(exception.Message, exception);
                throw new ExceptionNotFound(exception.Message);
            }
            return clientDto;
        }


    }
}
