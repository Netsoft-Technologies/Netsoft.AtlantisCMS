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
            CreateMap<OnlineStringModels, COnlineStringRO>().ReverseMap();
            CreateMap<COnlineStringEdit, OnlineStringModels>().ReverseMap();

            CreateMap<TestingTableModel, CTestingTableRO>().ReverseMap();
            CreateMap<CTestingTableEdit, TestingTableModel>().ReverseMap();

            CreateMap<OnlinePageModel, COnlinePageRO>().ReverseMap();
            CreateMap<OnlinePageModel, COnlinePageEdit>().ReverseMap();
            CreateMap<COnlinePageEdit, OnlinePageModel>().ReverseMap();

            CreateMap<COnlinePageComponentRO, OnlinePageComponentModel>().ReverseMap();
            CreateMap<OnlinePageComponentModel, COnlinePageComponentRO>().ReverseMap();
            CreateMap<OnlinePageComponentModel, COnlinePageComponent>().ReverseMap();
        }
    }
}
