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
        private readonly IMapper _mapper;

        public OnlinePagesController(IDataPortal<COnlinePagesRO> OnlinePagesDataPortal, IMapper mapper)
        {
            _OnlinePagesDataPortal = OnlinePagesDataPortal;
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
    }


}
