using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string SecondName{ get; set; }        
        public int RoleId{ get; set; }
        public IEnumerable<Operation> Operations { get; set; }


    }
}
