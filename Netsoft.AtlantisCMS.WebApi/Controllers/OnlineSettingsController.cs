using AutoMapper;
using Csla;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netsoft.AtlantisCMS.BusinessLibrary;
using Netsoft.AtlantisCMS.Models;

namespace Netsoft.AtlantisCMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineSettingsController : ControllerBase
    {
        private readonly IDataPortal<COnlineSettingsRO> _OnlineSettingsDataPortal;
        private readonly IDataPortal<COnlineSettingEdit> _OnlineSettingsEditPortal;
        private readonly IMapper _mapper;
        public OnlineSettingsController(IDataPortal<COnlineSettingsRO> settingPortal, IDataPortal<COnlineSettingEdit> settingEditPortal, IMapper mapper)
        {
            _OnlineSettingsDataPortal = settingPortal;
            _OnlineSettingsEditPortal = settingEditPortal;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<OnlineSettingModels>> GetOnlineSettings()
        {
            var onlineSettings = await _OnlineSettingsDataPortal.FetchAsync();
            if (onlineSettings == null)
            {
                return NotFound();
            }
            return Ok(onlineSettings);
        }
        //[HttpPost]
        //public async Task<ActionResult<OnlineSettingModels>> Create(OnlineSettingModels newSettingReq)
        //{
        //    if (newSettingReq == null || !ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    COnlineSettingEdit newOnlineSetting = await _OnlineSettingsEditPortal.CreateAsync();
        //    //newOnlineSetting.
        //}
    }
}
