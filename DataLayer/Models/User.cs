using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }     
        [Required]
        [MaxLength(50)]
        public string FirstName{ get; set; }
        [Required]
        [MaxLength(50)]
        public string SecondName { get; set; }
        [Required]
        [MaxLength(50)]
        public string MiddleName{ get; set; }
        public bool IsBusy { get; set; }

        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        public int UserStatusId { get; set; }
        public UserStatus UserStatus { get; set; }

        public IEnumerable<OperationUser> Operations { get; set; }
        public virtual IEnumerable<UserPosition> UserPositions { get; set; }
        public virtual IEnumerable<Mission> Missions { get; set; }



    }
}
