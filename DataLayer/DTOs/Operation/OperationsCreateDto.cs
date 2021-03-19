using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.DTOs.Operation
{
    class OperationsCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
