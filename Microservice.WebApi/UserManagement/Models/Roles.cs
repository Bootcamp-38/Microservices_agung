using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserManagement.Bases;

namespace UserManagement.Models
{
    [Table("TB_M_Role")]
    public class Roles : IEntity
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}
