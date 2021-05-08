using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class OperationUser
    {
        public int OperationId { get; set; }
        public int UserId { get; set; }
        public Operation Operation { get; set; }
        public User User { get; set; }

    }
}
