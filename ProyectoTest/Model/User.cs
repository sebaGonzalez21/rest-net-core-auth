using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTest.Model
{
    [Table("User")]
    public class User
    {
        private long _id;
        private string _userName;
        private string _userPassword;

        [Key]
        [Column("Id")]
        public long Id { get => _id; set => _id = value; }
        [Column("Name")]
        public string UserName { get => _userName; set => _userName = value; }
        [Column("Password")]
        public string UserPassword { get => _userPassword; set => _userPassword = value; }
       
    }
}
