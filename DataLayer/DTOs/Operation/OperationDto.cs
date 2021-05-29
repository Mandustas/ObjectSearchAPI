using System;
using DataLayer.Models;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTOs.Operation
{
    public class OperationDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsSuccess { get; set; }

        public OperationDTO(DataLayer.Models.Operation operation)
        {
            this.Id = operation.Id;
            this.Title = operation.Title;
            this.Date = operation.Date;
            this.IsSuccess = operation.IsSuccess;
        }
    }
}
