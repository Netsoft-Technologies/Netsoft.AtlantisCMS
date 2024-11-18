using AutoMapper;
using Csla;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netsoft.AtlantisCMS.BusinessLibrary;
using Netsoft.AtlantisCMS.Models;
using System.ComponentModel;

namespace Netsoft.AtlantisCMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineComponentsController : ControllerBase
    {
        private readonly IDataPortal<COnlineComponentsRO> _OnlineComponentsPortal;
        private readonly IDataPortal<COnlineComponentEdit> _OnlineComponentEditPortal;
        private readonly IMapper _mapper;
        public OnlineComponentsController(IDataPortal<COnlineComponentsRO> onlineComponentsDataPortal, IDataPortal<COnlineComponentEdit> onlineComponentEditDataPortal, IMapper mapper)
        {
            _OnlineComponentsPortal = onlineComponentsDataPortal;
            _OnlineComponentEditPortal = onlineComponentEditDataPortal;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<OnlineComponentModel>> GetOnlineComponents()
        {
            var onlineCompReq = await _OnlineComponentsPortal.FetchAsync();
            if (onlineCompReq == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<List<OnlineComponentModel>>(onlineCompReq);
            return Ok(result);
        }
        [HttpGet("{componentId}")]
        public async Task<ActionResult<OnlineComponentModel>> GetOnlineComponent(int componentId)
        {
            var singleCompReq = await _OnlineComponentEditPortal.FetchAsync(componentId);
            if (singleCompReq == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<OnlineComponentModel>(singleCompReq);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<OnlineComponentModel>> CreateComp(OnlineComponentModel compModel)
        {
            if (compModel == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            COnlineComponentEdit newComp = await _OnlineComponentEditPortal.CreateAsync();
            newComp.Description = compModel.Description;
            newComp.HTMLClassName = compModel.HTMLClassName;
            newComp.HTMLElementId = compModel.HTMLElementId;
            newComp.StringContentId = compModel.StringContentId;
            newComp.StylingGroupId = compModel.StylingGroupId;

            if (compModel.StylingProps != null)
            {
                foreach (var stylePropModel in compModel.StylingProps)
                {
                    var newStyleProp = newComp.StylingProps.AddNew();
                    newStyleProp.StylingPropertyId = stylePropModel.StylingPropertyId;
                    newStyleProp.ComponentId = newComp.Id;
                    newStyleProp.Value = stylePropModel.Value;
                }
            }

            newComp = await newComp.SaveAsync();
            var res = _mapper.Map<OnlineComponentModel>(newComp);
            return Ok(res);
        }
        [HttpPut("{componentId}")]
        public async Task<ActionResult<OnlineComponentModel>> EditComp(int componentId, OnlineComponentModel compModel)
        {
            if (compModel == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var editComp = await _OnlineComponentEditPortal.FetchAsync(componentId);
            editComp.Description = compModel.Description;
            editComp.HTMLClassName = compModel.HTMLClassName;
            editComp.HTMLElementId = compModel.HTMLElementId;
            editComp.StringContentId = compModel.StringContentId;
            editComp.StylingGroupId = compModel.StylingGroupId;

            editComp.StylingProps.RemoveByParent(componentId);
            if (compModel.StylingProps != null)
            {
                foreach (var stylePropModel in compModel.StylingProps)
                {
                    var newStyleProp = editComp.StylingProps.AddNew();
                    newStyleProp.StylingPropertyId = stylePropModel.StylingPropertyId;
                    newStyleProp.ComponentId = componentId;
                    newStyleProp.Value = stylePropModel.Value;
                }
            }

            editComp = await editComp.SaveAsync();
            var res = _mapper.Map<OnlineComponentModel>(editComp);
            return Ok(res);
        }
        [HttpDelete("{componentId}")]
        public async Task<IActionResult> DeleteComp(int componentId)
        {
            var compToDelete = await _OnlineComponentEditPortal.FetchAsync(componentId);
            if (compToDelete == null || compToDelete.Id == 0)
            {
                return NotFound($"Component with id: {componentId} not found.");
            }
            try
            {
                await _OnlineComponentEditPortal.DeleteAsync(componentId);
                compToDelete.StylingProps.RemoveByParent(componentId);
                return Ok("Deleted component with associated styling");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting component: {ex.Message}");
            }
        }

    }
}
