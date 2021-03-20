using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataLayer.DTOs.Operation;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Profiles
{
    class TargetProfile : Profile
    {
        public TargetProfile()
        {
            CreateMap<Target, TargetCreateDto>();
            CreateMap<TargetCreateDto, Target>();
            CreateMap<TargetUpdateDto, Target>();
        }
    }
}
