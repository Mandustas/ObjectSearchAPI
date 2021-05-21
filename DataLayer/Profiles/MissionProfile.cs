using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataLayer.DTOs.Operation;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Profiles
{
    class MissionProfile : Profile
    {
        public MissionProfile()
        {
            CreateMap<Mission, TargetCreateDto>();
            CreateMap<MissionCreateDto, Mission>();
        }
    }
}
