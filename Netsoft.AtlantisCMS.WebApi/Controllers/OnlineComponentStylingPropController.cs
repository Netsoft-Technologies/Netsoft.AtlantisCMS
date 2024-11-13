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
    public class OnlineComponentStylingPropController : ControllerBase
    {
        private readonly IDataPortal<COnlineCompStylingPropsRO> _OnlineCompPropsPortal;
        private readonly IDataPortal<COnlineCompStylingProp> _OnlineCompPropEditPortal;
        private readonly IMapper _mapper;
        public OnlineComponentStylingPropController(IDataPortal<COnlineCompStylingPropsRO> OnlineProps, IDataPortal<COnlineCompStylingProp> OnlinePropEdit, IMapper mapper)
        {
            _OnlineCompPropsPortal = OnlineProps;
            _OnlineCompPropEditPortal = OnlinePropEdit;
            _mapper = mapper;
        }
        [HttpGet()]
        public async Task<ActionResult<OnlineComponentStylingPropertyModel>> GetOnlineCompStylingProps()
        {
            var onlineCompPropRequest = await _OnlineCompPropsPortal.FetchAsync();
            if (onlineCompPropRequest == null)
            {
                return NotFound();
            }
            return Ok(onlineCompPropRequest);
        }
        [HttpGet("{compStyleId}")]
        public async Task<ActionResult<OnlineComponentStylingPropertyModel>> GetOnlineCompStylingProperty(int compStyleId)
        {
            var compStyle = await _OnlineCompPropEditPortal.FetchAsync();
            if (compStyle == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<OnlineComponentStylingPropertyModel>(compStyle);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<OnlineComponentStylingPropertyModel>> CreateStyle(OnlineComponentStylingPropertyModel reqModel)
        {
            if (reqModel == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            COnlineCompStylingProp newStyleProp = await _OnlineCompPropEditPortal.CreateAsync();
            newStyleProp.StylingPropertyId = reqModel.StylingPropertyId;
            newStyleProp.ComponentId = reqModel.ComponentId;
            newStyleProp.Value = reqModel.Value;
            newStyleProp = await newStyleProp.SaveAsync();
            var res = _mapper.Map<OnlineComponentStylingPropertyModel>(newStyleProp);
            return Ok(res);
        }
        [HttpPut("{compStyleId}")]
        public async Task<ActionResult<OnlineComponentStylingPropertyModel>> EditStyle(int compStyleId, OnlineComponentStylingPropertyModel reqModel)
        {
            if (!ModelState.IsValid || reqModel == null || compStyleId == 0)
            {
                return BadRequest(ModelState);
            }
            var editCompStyle = await _OnlineCompPropEditPortal.FetchAsync(compStyleId);
            if (editCompStyle.StylingPropertyId != compStyleId)
            {
                return BadRequest(ModelState);
            }
            editCompStyle.ComponentId = reqModel.ComponentId;
            editCompStyle.Value = reqModel.Value;
            editCompStyle = await editCompStyle.SaveAsync();
            var res = _mapper.Map<OnlineComponentStylingPropertyModel>(editCompStyle);
            return Ok(res);
        }
        [HttpDelete("{compStyleId}")]
        public async Task<IActionResult> DeleteCompStyle(int compStyleId)
        {
            var compStyleForDeletion = await _OnlineCompPropEditPortal.FetchAsync(compStyleId);
            if (compStyleForDeletion == null || compStyleForDeletion.StylingPropertyId == 0)
            {
                return NotFound($"Component style with id: {compStyleId} not found.");
            }
            try
            {
                await _OnlineCompPropEditPortal.DeleteAsync(compStyleId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting component style: {ex.Message}"); ;
            }
        }
    }
}
