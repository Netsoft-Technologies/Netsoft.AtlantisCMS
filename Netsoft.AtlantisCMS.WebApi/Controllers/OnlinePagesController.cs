using AutoMapper;
using Csla;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Netsoft.AtlantisCMS.BusinessLibrary;
using Netsoft.AtlantisCMS.Models;

namespace Netsoft.AtlantisCMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlinePagesController : ControllerBase
    {
        private readonly IDataPortal<COnlinePagesRO> _OnlinePagesDataPortal;
        private readonly IDataPortal<COnlinePageEdit> _OnlinePageEditDataPortal;
        private readonly IMapper _mapper;

        public OnlinePagesController(IDataPortal<COnlinePagesRO> onlinePagesDataPortal, IDataPortal<COnlinePageEdit> onlinePageEditDataPortal, IMapper mapper)
        {
            _OnlinePagesDataPortal = onlinePagesDataPortal;
            _OnlinePageEditDataPortal = onlinePageEditDataPortal;
            _mapper = mapper;
        }
        [HttpGet()]
        public async Task<ActionResult<List<OnlinePageModel>>> GetAllPages()
        {
            var pagesRequest = await _OnlinePagesDataPortal.FetchAsync();
            if (pagesRequest == null)
            {
                return NotFound();
            }
            return Ok(pagesRequest);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OnlinePageModel>> GetSinglePage(int id)
        {
            var page = await _OnlinePageEditDataPortal.FetchAsync(id);
            if (page == null || page.PageId == 0)
            {
                return NotFound();
            }
            var result = _mapper.Map<OnlinePageModel>(page);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<OnlinePageModel>> CreatePage(OnlinePageModel onlinePagePost)
        {
            if (onlinePagePost == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            COnlinePageEdit newPage = await _OnlinePageEditDataPortal.CreateAsync();
            newPage.PageTitle = onlinePagePost.PageTitle;
            newPage.PageOrder = onlinePagePost.PageOrder;
            newPage = await newPage.SaveAsync();
            var result = _mapper.Map<OnlinePageModel>(newPage);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<OnlinePageModel>> EditPage(OnlinePageModel onlinePageEdit)
        {
            if (onlinePageEdit == null || onlinePageEdit.PageId == 0 || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newPageEdit = await _OnlinePageEditDataPortal.FetchAsync(onlinePageEdit.PageId);
            if (newPageEdit.PageId != onlinePageEdit.PageId)
            {
                return BadRequest("Missmatch");
            }
            //newPageEdit.PageId = onlinePageEdit.PageId;
            newPageEdit.PageTitle = onlinePageEdit.PageTitle;
            newPageEdit.PageOrder = onlinePageEdit.PageOrder;
            newPageEdit = await newPageEdit.SaveAsync();
            var result = _mapper.Map<OnlinePageModel>(newPageEdit);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePage (int id)
        {
            try
            {
                await _OnlinePageEditDataPortal.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting page: {ex.Message}");
            }
        }
    }
}
