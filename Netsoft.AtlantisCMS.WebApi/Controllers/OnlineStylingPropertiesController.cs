using AutoMapper;
using Csla;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Netsoft.AtlantisCMS.BusinessLibrary;
using Netsoft.AtlantisCMS.Models;

namespace Netsoft.AtlantisCMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineStylingPropertiesController : ControllerBase
    {
        private readonly IDataPortal<COnlineStylingPropertiesRO> _OnlineStylingPropsPortal;
        private readonly IDataPortal<COnlineStylingPropertyEdit> _OnlineStylingPropsEditPortal;
        private readonly IMapper _mapper;
        public OnlineStylingPropertiesController(IDataPortal<COnlineStylingPropertiesRO> propPortal, IDataPortal<COnlineStylingPropertyEdit> editPortal, IMapper mapper)
        {
            _OnlineStylingPropsPortal = propPortal;
            _OnlineStylingPropsEditPortal = editPortal;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<OnlineStylingPropertyModel>> GetOnlineStylingProperties()
        {
            var onlineStyleProps = await _OnlineStylingPropsPortal.FetchAsync();
            if (onlineStyleProps == null)
            {
                return NotFound();
            }
            return Ok(onlineStyleProps);
        }
        [HttpGet("{styleId}")]
        public async Task<ActionResult<OnlineStylingPropertyModel>> GetOnlineStylingProperty(int styleId)
        {
            var singleStyleProp = await _OnlineStylingPropsEditPortal.FetchAsync(styleId);
            if (singleStyleProp == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<OnlineStylingPropertyModel>(singleStyleProp);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<OnlineStylingPropertyModel>> Create(OnlineStylingPropertyModel newStylePropreq)
        {
            if (newStylePropreq == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            COnlineStylingPropertyEdit newOnlineStyleProp = await _OnlineStylingPropsEditPortal.CreateAsync();
            newOnlineStyleProp.Id = newStylePropreq.Id;
            newOnlineStyleProp.Desc = newStylePropreq.Description;
            newOnlineStyleProp.CSS = newStylePropreq.CSSProperty;
            newOnlineStyleProp = await newOnlineStyleProp.SaveAsync();
            var res = _mapper.Map<OnlineStylingPropertyModel>(newOnlineStyleProp);
            return Ok(res);
        }
        [HttpPut("{styleId}")]
        public async Task<ActionResult<OnlineStylingPropertyModel>> Update(int styleId, OnlineStylingPropertyModel newStylePropreq)
        {
            if (!ModelState.IsValid || newStylePropreq == null || newStylePropreq.Id == 0)
            {
                return BadRequest(ModelState);
            }
            var editStyleProp = await _OnlineStylingPropsEditPortal.FetchAsync(styleId);
            if (editStyleProp.Id != styleId)
            {
                return BadRequest(ModelState);
            }
            editStyleProp.Id = newStylePropreq.Id;
            editStyleProp.Desc = newStylePropreq.Description;
            editStyleProp.CSS = newStylePropreq.CSSProperty;
            editStyleProp = await editStyleProp.SaveAsync();
            var res = _mapper.Map<OnlineStylingPropertyModel>(editStyleProp);
            return Ok(res);
        }
        [HttpDelete("{styleId}")]
        public async Task<IActionResult> Delete(int styleId)
        {
            var styleToDelete = await _OnlineStylingPropsEditPortal.FetchAsync(styleId);
            if (styleToDelete == null || styleToDelete.Id == 0)
            {
                return NotFound($"Styling property with id: {styleId} not found.");
            }
            try
            {
                await _OnlineStylingPropsEditPortal.DeleteAsync(styleId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting styling property: {ex.Message}");
            }
        }
    }
}
