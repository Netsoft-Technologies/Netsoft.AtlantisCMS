﻿using AutoMapper;
using Netsoft.AtlantisCMS.BusinessLibrary;
using Netsoft.AtlantisCMS.Dal;
using Netsoft.AtlantisCMS.Models;
using Netsoft.AtlantisCMS.WebApi.Infrastructure;

namespace Netsoft.AtlantisCMS.WebApi.Infrastructure
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        { 
            CreateMap<OnlinePageModel, COnlinePageRO>().ReverseMap();
        }
    }
}