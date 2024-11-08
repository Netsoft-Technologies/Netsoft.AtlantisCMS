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
            return Ok(onlineCompReq);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OnlineComponentModel>> GetOnlineComponent(int id)
        {
            var singleCompReq = await _OnlineComponentEditPortal.FetchAsync(id);
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
            newComp.CompDesc = compModel.Description;
            newComp.CompHTMLClass = compModel.HTMLClassName;
            newComp.CompHTMLElement = compModel.HTMLElementId;
            newComp.StringContentId = compModel.StringContentId;
            newComp = await newComp.SaveAsync();
            var res = _mapper.Map<OnlineComponentModel>(newComp);
            return Ok(res);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<OnlineComponentModel>> EditComp(int id, OnlineComponentModel compModel)
        {
            if (compModel == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var editComp = await _OnlineComponentEditPortal.FetchAsync(id);
            if (editComp.CompId != id)
            {
                return BadRequest(ModelState);
            }
            editComp.CompDesc = compModel.Description;
            editComp.CompHTMLClass = compModel.HTMLClassName;
            editComp.CompHTMLElement = compModel.HTMLElementId;
            editComp.StringContentId = compModel.StringContentId;
            editComp = await editComp.SaveAsync();
            var res = _mapper.Map<OnlineComponentModel>(editComp);
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComp(int id)
        {
            try
            {
                await _OnlineComponentEditPortal.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting ticket: {ex.Message}");
            }
        }

    }
}
