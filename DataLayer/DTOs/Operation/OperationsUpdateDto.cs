using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.DTOs.Operation
{
    public class OperationsUpdateDto
    {
        [Required]
        public bool IsSuccess { get; set; }

    }
}
