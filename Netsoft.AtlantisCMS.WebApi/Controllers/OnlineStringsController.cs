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
        [HttpGet("{id}")]
        public async Task<ActionResult<OnlineStringModels>> GetSingleOnlineString(int id)
        {
            var page = await _OnlineStringEditDataPortal.FetchAsync(id);
            if (page == null)
            {
                return NotFound($"");
            }
            var result = _mapper.Map<OnlineStringModels>(page);
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
        [HttpPut]
        public async Task<ActionResult<OnlineStringModels>> Edit(OnlineStringModels onlineString)
        {
            if (!ModelState.IsValid || onlineString.Id == 0 || onlineString == null)
            {
                return BadRequest(ModelState);
            }
            var newOnlineStyleProp = await _OnlineStringEditDataPortal.FetchAsync(onlineString.Id);
            if (newOnlineStyleProp.Id != onlineString.Id)
            {
                return BadRequest(ModelState);
            }
            newOnlineStyleProp.Id = onlineString.Id;
            newOnlineStyleProp.Title = onlineString.Title;
            newOnlineStyleProp.MessageId = onlineString.MessageId;
            newOnlineStyleProp.Message = onlineString.Message;
            newOnlineStyleProp.MessageType= onlineString.MessageType;
            newOnlineStyleProp = await newOnlineStyleProp.SaveAsync();
            var result = _mapper.Map<OnlineStringModels>(newOnlineStyleProp);
            return Ok(result);
        }
        [HttpPost("createMultiple")]
        public async Task<ActionResult<List<OnlineStringModels>>> CreateMultiple(List<OnlineStringModels> onlineStrings)
        {
            if (onlineStrings == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = new List<OnlineStringModels>();
            foreach (var singleOnlineString in onlineStrings)
            {
                COnlineStringEdit newOnlineStyleProp = await _OnlineStringEditDataPortal.CreateAsync();
                newOnlineStyleProp.Title = singleOnlineString.Title;
                newOnlineStyleProp.MessageId = singleOnlineString.MessageId;
                newOnlineStyleProp.Message = singleOnlineString.Message;
                newOnlineStyleProp.MessageType = singleOnlineString.MessageType;
                list.Add(_mapper.Map<OnlineStringModels>(newOnlineStyleProp));
            }
            return Ok(list);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteticket(int id)
        {
            try
            {
                await _OnlineStringEditDataPortal.DeleteAsync(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting string: {ex.Message}");
            }
        }
    }
}
