using System;
/**
 * Sebastian Gonzalez
 * */
namespace ProyectoTest.Dto
{
    [Serializable]
    public class ClientDto
    {
        private long _idDto;
        private string _nameDto;

        public long IdDto { get => _idDto; set => _idDto = value; }
        public string NameDto { get => _nameDto; set => _nameDto = value; }
    }
}
