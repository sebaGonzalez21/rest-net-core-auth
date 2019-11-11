using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/**
 * Sebastian Gonzalez
 * 
 * */
namespace ProyectoTest.Model
{
    [Table("Client")]
    public class Client
    {
        private long _id;
        private string _name;

        [Key]
        [Column("Id")]
        public long Id { get => _id; set => _id = value; }
        [Column("Name")]
        public string Name { get => _name; set => _name = value; }
    }
}
