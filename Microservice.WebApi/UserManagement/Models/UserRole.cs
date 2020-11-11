using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserManagement.Bases;

namespace UserManagement.Models
{
    [Table("TB_M_UserRole")]
    public class UserRole : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; }

    }
}
