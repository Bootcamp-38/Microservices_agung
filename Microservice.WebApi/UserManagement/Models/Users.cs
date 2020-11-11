using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserManagement.Bases;

namespace UserManagement.Models
{
    [Table("TB_M_User")]
    public class Users : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsUpdatePassword { get; set; }
        public Employees Employee { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public Roles Role { get; set; }

    }
}
