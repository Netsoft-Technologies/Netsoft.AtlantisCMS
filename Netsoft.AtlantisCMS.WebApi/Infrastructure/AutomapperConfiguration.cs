using AutoMapper;
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

            CreateMap<OnlineComponentStylingPropertyModel, COnlineCompStylingPropRO>().ReverseMap();
            CreateMap<OnlineComponentStylingPropertyModel, COnlineCompStylingProp>().ReverseMap();

            CreateMap<OnlineComponentModel, COnlineComponentEdit>().ReverseMap();
            CreateMap<OnlineComponentModel, COnlineComponentRO>().ReverseMap();
            CreateMap<COnlineComponentEdit, OnlineComponentModel>().ReverseMap();
            CreateMap<COnlineComponentRO, OnlineComponentModel>().ReverseMap();
            CreateMap<OnlineComponentCreateRequestModel, COnlineComponentRO>().ReverseMap();

            CreateMap<OnlineSettingModels, COnlineSettingEdit>().ReverseMap();
            CreateMap<OnlineSettingModels, COnlineSettingRO>().ReverseMap();
            CreateMap<COnlineSettingEdit, OnlineSettingModels>().ReverseMap();

            CreateMap<OnlineStylingPropertyModel, COnlineStylingPropertyEdit>().ReverseMap();
            CreateMap<OnlineStylingPropertyModel, COnlineStylingPropertyRO>().ReverseMap();
            CreateMap<COnlineStylingPropertyEdit, OnlineStylingPropertyModel>().ReverseMap();

            CreateMap<OnlineStringModels, COnlineStringEdit>().ReverseMap();
            CreateMap<OnlineStringModels, COnlineStringRO>().ReverseMap();
            CreateMap<COnlineStringEdit, OnlineStringModels>().ReverseMap();

            CreateMap<OnlinePageModel, COnlinePageRO>().ReverseMap();
            CreateMap<OnlinePageModel, COnlinePageEdit>().ReverseMap();
            CreateMap<COnlinePageEdit, OnlinePageModel>().ReverseMap();

            CreateMap<COnlinePageComponentRO, OnlinePageComponentModel>().ReverseMap();
            CreateMap<OnlinePageComponentModel, COnlinePageComponentRO>().ReverseMap();
            CreateMap<OnlinePageComponentModel, COnlinePageComponent>().ReverseMap();
            CreateMap<OnlinePageComponentModel, COnlineCompStylingProp>().ReverseMap();
        }
    }
}
