using HaliaExamAPI.DAL.Abstract;
using HaliaExamAPI.DAL.Concrate;
using HaliaExamAPI.Models;
using HaliaExamAPI.Models.TempModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaliaExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AssignedCaseController : ControllerBase
    {
        private readonly IAssignedCaseService _assignedCaseRepository;

        public AssignedCaseController(IAssignedCaseService assignedCaseService)
        {
            _assignedCaseRepository = assignedCaseService;
        }

        [HttpPost("CreateAssignedCase")]
        public IActionResult Create([FromBody]AssignedCase assignedCase,int sessionUserId)
        {
            if (sessionUserId != 0)
            {
                assignedCase.status = "Assigned";
                assignedCase.actioneduserid = sessionUserId;
                _assignedCaseRepository.Insert(assignedCase);
                _assignedCaseRepository.InsertCaseStatus(assignedCase.caseid, sessionUserId);
                _assignedCaseRepository.UpdateCase(assignedCase.caseid);

                return Ok("Success");
            }

            return Ok("Failure");
        }

        [HttpGet("UserAssignedCasesList")]
        public IActionResult UserAssignedCasesList(int sessionUserId)
        {
            var userAssignedCases = _assignedCaseRepository.userAssignedCasesList(sessionUserId);
            if (userAssignedCases != null)
            {
                return Ok(userAssignedCases);
            }

            return NotFound();
        }

        [HttpGet("AssignedCaseAnswer")]
        public IActionResult AssignedCaseAnswer(int id)
        {
            var userAssignedCases = _assignedCaseRepository.GetAssignedCaseAnswer(id);
            
            if (userAssignedCases != null)
            {
                return Ok(userAssignedCases);
            }

            return NotFound();
        }
    }
}