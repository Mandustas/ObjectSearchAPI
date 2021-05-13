using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsSuccess { get; set; } 
        public int? CoordinatorId { get; set; }
        public User Coordinator { get; set; }
        public IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<Target> Targets { get; set; }
        public List<OperationUser> OperationUsers { get; set; }

    }
}
