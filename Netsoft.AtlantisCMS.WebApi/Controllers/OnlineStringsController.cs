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
    public class OnlineStringsController : ControllerBase
    {
        private readonly IDataPortal<COnlineStringsRO> _OnlineStringsDataPortal;
        private readonly IDataPortal<COnlineStringEdit> _OnlineStringEditDataPortal;
        private readonly IMapper _mapper;
        public OnlineStringsController(IDataPortal<COnlineStringsRO> onlineStringsDataPortal, IDataPortal<COnlineStringEdit> onlineStringEditDataPortal, IMapper mapper)
        {
            _OnlineStringsDataPortal = onlineStringsDataPortal;
            _OnlineStringEditDataPortal = onlineStringEditDataPortal;
            _mapper = mapper;
        }
        [HttpGet()]
        public async Task<ActionResult<OnlineStringModels>> GetOnlineStrings()
        {
            var OnlineStringsRequest = await _OnlineStringsDataPortal.FetchAsync();
            if (OnlineStringsRequest == null)
            {
                return NotFound();
            }
            return Ok(OnlineStringsRequest);
        }
        [HttpGet("{stringId}")]
        public async Task<ActionResult<OnlineStringModels>> GetSingleOnlineString(int stringId)
        {
            var stringEntry = await _OnlineStringEditDataPortal.FetchAsync(stringId);
            if (stringEntry == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<OnlineStringModels>(stringEntry);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<OnlineStringModels>> Create(OnlineStringModels onlineString)
        {
            if (onlineString == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            COnlineStringEdit newOnlineStyleProp = await _OnlineStringEditDataPortal.CreateAsync();
            newOnlineStyleProp.Title = onlineString.Title;
            newOnlineStyleProp.MessageId = onlineString.MessageId;
            newOnlineStyleProp.Message = onlineString.Message;
            newOnlineStyleProp.MessageType = onlineString.MessageType;
            newOnlineStyleProp = await newOnlineStyleProp.SaveAsync();
            var result = _mapper.Map<OnlineStringModels>(newOnlineStyleProp);
            return Ok(result);
        }
        [HttpPut("{stringId}")]
        public async Task<ActionResult<OnlineStringModels>> Edit(int stringId, OnlineStringModels onlineString)
        {
            if (!ModelState.IsValid || onlineString == null)
            {
                return BadRequest("Invalid Request");
            }
            var editOnlineStyleProp = await _OnlineStringEditDataPortal.FetchAsync(stringId);
            if (editOnlineStyleProp.Id != stringId)
            {
                return BadRequest("Invalid Request");
            }
            editOnlineStyleProp.Title = onlineString.Title;
            editOnlineStyleProp.MessageId = editOnlineStyleProp.MessageId;
            editOnlineStyleProp.Message = onlineString.Message;
            editOnlineStyleProp.MessageType= onlineString.MessageType;
            editOnlineStyleProp = await editOnlineStyleProp.SaveAsync();
            var result = _mapper.Map<OnlineStringModels>(editOnlineStyleProp);
            return Ok(result);
        }
        [HttpDelete("{stringId}")]
        public async Task<ActionResult<OnlineStringModels>> Deleteticket(int stringId)
        {
            var stringForDeletion = await _OnlineStringEditDataPortal.FetchAsync(stringId);
            if (stringForDeletion == null || stringForDeletion.Id == 0)
            {
                return NotFound($"String with id: {stringId} not found.");
            }
            try
            {
                await _OnlineStringEditDataPortal.DeleteAsync(stringId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting string: {ex.Message}");
            }
        }
        //[HttpPost("createMultiple")]
        //public async Task<ActionResult<List<OnlineStringModels>>> CreateMultiple(List<OnlineStringModels> onlineStrings)
        //{
        //    if (onlineStrings == null || !ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var list = new List<OnlineStringModels>();
        //    foreach (var singleOnlineString in onlineStrings)
        //    {
        //        COnlineStringEdit newOnlineStyleProp = await _OnlineStringEditDataPortal.CreateAsync();
        //        newOnlineStyleProp.Title = singleOnlineString.Title;
        //        newOnlineStyleProp.MessageId = singleOnlineString.MessageId;
        //        newOnlineStyleProp.Message = singleOnlineString.Message;
        //        newOnlineStyleProp.MessageType = singleOnlineString.MessageType;
        //        list.Add(_mapper.Map<OnlineStringModels>(newOnlineStyleProp));
        //    }
        //    return Ok(list);
        //}
    }
}
