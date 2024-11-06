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
    public class TestingTableController : ControllerBase
    {
        private readonly IDataPortal<CTestingTablesRO> _TestingDataPortal;
        private readonly IDataPortal<CTestingTableEdit> _TestingEditDataPortal;
        private readonly IMapper _mapper;
        public TestingTableController(IDataPortal<CTestingTablesRO> testingDataPortal, IDataPortal<CTestingTableEdit> editPortal, IMapper mapper)
        {
            _TestingDataPortal = testingDataPortal;
            _TestingEditDataPortal = editPortal;
            _mapper = mapper;
        }
        [HttpGet()]
        public async Task<ActionResult<TestingTableModel>> GetAllTests()
        {
            var testsRequest = await _TestingDataPortal.FetchAsync();
            if (testsRequest == null)
            {
                return NotFound();
            }
            return Ok(testsRequest);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TestingTableModel>> GetSingleTest(int id)
        {
            var testPage = await _TestingEditDataPortal.FetchAsync(id);
            if (testPage == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<TestingTableModel>(testPage);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<TestingTableModel>> CreateTestEntry(TestingTableModel testingTable)
        {
            if (testingTable == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            CTestingTableEdit testingTablePost = await _TestingEditDataPortal.CreateAsync();
            testingTablePost.TestTitle = testingTable.TestTitle;
            testingTablePost.TestContent = testingTable.TestContent;
            testingTablePost.TestOrder = testingTable.TestOrder;
            testingTablePost.TestDate = DateTime.Now;
            testingTablePost =await testingTablePost.SaveAsync();
            var result = _mapper.Map<TestingTableModel>(testingTablePost);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<TestingTableModel>> EditEntry(TestingTableModel testEdit)
        {
            if (!ModelState.IsValid || testEdit.TestId == 0 || testEdit == null)
            {
                return BadRequest();
            }
            var entryEdit = await _TestingEditDataPortal.FetchAsync(testEdit.TestId);
            if (entryEdit.TestId != testEdit.TestId)
            {
                return BadRequest();
            }
            entryEdit.TestId = testEdit.TestId;
            entryEdit.TestTitle = testEdit.TestTitle;
            entryEdit.TestContent = testEdit.TestContent;
            entryEdit.TestOrder = testEdit.TestOrder;
            entryEdit.TestDate = testEdit.TestDate;
            entryEdit = await entryEdit.SaveAsync();
            var result = _mapper.Map<TestingTableModel>(entryEdit);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest (int id)
        {
            try
            {
                await _TestingEditDataPortal.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting string: {ex.Message}");
            }
        }
    }
}
