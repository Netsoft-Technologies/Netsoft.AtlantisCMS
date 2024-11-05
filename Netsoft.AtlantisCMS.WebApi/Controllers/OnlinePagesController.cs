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
    public class OnlinePagesController : ControllerBase
    {
        private readonly IDataPortal<COnlinePagesRO> _OnlinePagesDataPortal;
        private readonly IDataPortal<COnlinePageEdit> _OnlinePagesEditDataPortal;
        private readonly IMapper _mapper;

        public OnlinePagesController(IDataPortal<COnlinePagesRO> OnlinePagesDataPortal,IDataPortal<COnlinePageEdit>OnlinePageEditDP, IMapper mapper)
        {
            _OnlinePagesDataPortal = OnlinePagesDataPortal;
            _OnlinePagesEditDataPortal = OnlinePageEditDP;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<OnlinePageModel>> GetOnlinePages()
        {
            var OnlinePagesrequest = await _OnlinePagesDataPortal.FetchAsync();
            if (OnlinePagesrequest == null)
            {
                return NotFound($"");
            }

            return Ok(OnlinePagesrequest);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OnlinePageModel>> Get(int id)
        {
            var page = await _OnlinePagesEditDataPortal.FetchAsync(id);
            if (page == null)
            {
                return NotFound($"");
            }
            var result = _mapper.Map<OnlinePageModel>(page);
            return Ok(result);
        }
    }


}
