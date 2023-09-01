using HaliaExamAPI.DAL.Abstract;
using HaliaExamAPI.DAL.Concrate;
using HaliaExamAPI.Models;
using HaliaExamAPI.Models.TempModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaliaExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseStatusController : ControllerBase
    {
        private readonly ICaseStatusService _caseStatusRepository;

        public CaseStatusController(ICaseStatusService caseStatusService)
        {
            _caseStatusRepository = caseStatusService;
        }

        [HttpPost("CreateCaseStatus")]
        public IActionResult Create(AssignedCaseAnswer  assignedCaseAnswer, int sessionUserId)
        {
            if (sessionUserId != 0)
            {
                _caseStatusRepository.Insert(assignedCaseAnswer,sessionUserId);
                _caseStatusRepository.UpdateCase(assignedCaseAnswer.CaseId,assignedCaseAnswer.Status);
                _caseStatusRepository.UpdateAssignedCase(assignedCaseAnswer.Id, assignedCaseAnswer.Status);
               
                return Ok("Success");
            }

            return Ok("Failure");
        }


        [HttpGet("GetByCaseId")]
        public IActionResult GetByCaseId(int caseId)
        {
            var casesStatus = _caseStatusRepository.GetByCaseId(caseId);

            if (casesStatus != null)
            {
                return Ok(casesStatus);
            }

            return NotFound();
        }
    }
}