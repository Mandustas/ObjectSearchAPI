using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataLayer.DTOs.Operation;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Profiles
{
    class OperationProfile : Profile
    {
        public OperationProfile()
        {
            CreateMap<Operation, OperationsCreateDto>();
            CreateMap<OperationsCreateDto, Operation>();
            CreateMap<OperationsUpdateDto, Operation>();
        }
    }
}
