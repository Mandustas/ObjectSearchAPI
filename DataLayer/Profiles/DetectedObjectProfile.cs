using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataLayer.DTOs.DetectedObjects;
using DataLayer.DTOs.Operation;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Profiles
{
    class DetectedObjectProfile : Profile
    {
        public DetectedObjectProfile()
        {
            CreateMap<DetectedObject, DetectedObjectCreateDto>();
            CreateMap<DetectedObjectCreateDto, DetectedObject>();
            CreateMap<DetectedObjectUpdateDto, DetectedObject>();
        }
    }
}
