using AutoMapper;
using Csla;
using Csla.Server;
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
        [HttpGet]
        public async Task<ActionResult<List<OnlinePageModel>>> GetAllPages()
        {
            var pagesRequest = await _OnlinePagesDataPortal.FetchAsync();
            if (pagesRequest == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<List<OnlinePageModel>>(pagesRequest);
            return Ok(res);
        }
        [HttpGet("{pageId}")]
        public async Task<ActionResult<OnlinePageModel>> GetSinglePage(int pageId)
        {
            var page = await _OnlinePageEditDataPortal.FetchAsync(pageId);
            if (page == null || page.PageId == 0)
            {
                return NotFound($"Page with id: '{pageId}' was not found");
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

            if (onlinePagePost.Components != null)
            {
                foreach (var comp in onlinePagePost.Components)
                {
                    var pagecomp = newPage.Components.AddNew();
                    pagecomp.ComponentId = comp.ComponentId;
                }
            }
            newPage = await newPage.SaveAsync();
            var result = _mapper.Map<OnlinePageModel>(newPage);
            return Ok(result);
        }
        [HttpPut("{pageId}")]
        public async Task<ActionResult<OnlinePageModel>> EditPage(int pageId, OnlinePageModel onlinePageEdit)
        {
            if (onlinePageEdit == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newPageEdit = await _OnlinePageEditDataPortal.FetchAsync(pageId);
            if (newPageEdit.PageId == 0)
            {
                return NotFound($"Page with id: {pageId} not found.");
            }
            if (newPageEdit.PageId != pageId)
            {
                return BadRequest(ModelState);
            }
            newPageEdit.PageId = pageId;
            newPageEdit.PageTitle = onlinePageEdit.PageTitle;
            newPageEdit.PageOrder = onlinePageEdit.PageOrder;

            newPageEdit.Components.RemoveByParent(pageId);
            if (onlinePageEdit.Components != null)
            {
                foreach (var comp in onlinePageEdit.Components)
                {
                    var pagecomp = newPageEdit.Components.AddNew();
                    pagecomp.ComponentId = comp.ComponentId;
                }
            }

            newPageEdit = await newPageEdit.SaveAsync();
            var result = _mapper.Map<OnlinePageModel>(newPageEdit);
            return Ok(result);
        }
        [HttpDelete("{pageId}")]
        public async Task<ActionResult<OnlinePageModel>> DeletePage (int pageId)
        {
            var pageForDeletion = await _OnlinePageEditDataPortal.FetchAsync(pageId);
            if (pageForDeletion == null || pageForDeletion.PageId == 0)
            {
                return NotFound($"Page with id: {pageId} not found.");
            }
            try
            {
                await _OnlinePageEditDataPortal.DeleteAsync(pageId);
                pageForDeletion.Components.RemoveByParent(pageId);
                return Ok("Deleted Page with associated Components");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting page: {ex.Message}");
            }
        }
    }
}
