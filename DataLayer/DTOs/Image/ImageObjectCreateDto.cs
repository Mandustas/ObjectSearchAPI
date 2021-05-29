using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.DTOs.Images
{
    public class ImageObjectCreateDto
    {
        public string Path { get; set; }
        public DateTime DateCreate { get; set; }

    }
}
