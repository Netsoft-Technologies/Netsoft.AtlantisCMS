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
        [HttpPost]
        public async Task<ActionResult<OnlineComponentStylingPropertyModel>> CreateStyle(OnlineComponentStylingPropertyModel reqModel)
        {
            if (reqModel == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            COnlineCompStylingProp newStyleProp = await _OnlineCompPropEditPortal.CreateAsync();
            newStyleProp.StylingPropId = reqModel.StylingPropId;
            newStyleProp.ParentCompId = reqModel.ParentCompId;
            newStyleProp.StyleValue = reqModel.StyleValue;
            newStyleProp = await newStyleProp.SaveAsync();
            var res = _mapper.Map<OnlineComponentStylingPropertyModel>(newStyleProp);
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult<OnlineComponentStylingPropertyModel>> EditStyle(OnlineComponentStylingPropertyModel reqModel)
        {
            if (!ModelState.IsValid || reqModel == null || reqModel.StylingPropId == 0)
            {
                return BadRequest(ModelState);
            }
            var editCompStyle = await _OnlineCompPropEditPortal.FetchAsync(reqModel.StylingPropId);
            if (editCompStyle.StylingPropId != reqModel.StylingPropId)
            {
                return BadRequest(ModelState);
            }
            editCompStyle.StylingPropId = reqModel.StylingPropId;
            editCompStyle.ParentCompId = reqModel.ParentCompId;
            editCompStyle.StyleValue = reqModel.StyleValue;
            editCompStyle = await editCompStyle.SaveAsync();
            var res = _mapper.Map<OnlineComponentStylingPropertyModel>(editCompStyle);
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompStyle(int id)
        {
            try
            {
                await _OnlineCompPropEditPortal.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting component style: {ex.Message}"); ;
            }
        }
    }
}
