using HaliaExamAPI.DAL.Abstract;
using HaliaExamAPI.DAL.Concrate;
using HaliaExamAPI.Models;
using HaliaExamAPI.Models.TempModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HaliaExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CaseController : ControllerBase
    {
        private readonly ICaseService _caseRepository;

        public CaseController(ICaseService caseRepository)
        {
            _caseRepository = caseRepository;
        }

        [HttpPost("CreateCase")]
        public IActionResult Create(Case myCase,int sessionUserId)
        {
            if (sessionUserId != 0)
            {
                myCase.status = "Active";
                myCase.openeduserid = sessionUserId;
                _caseRepository.Insert(myCase);
                _caseRepository.InsertCaseStatus(myCase.id, sessionUserId);

                return Ok("Success");
            }

            return Ok("Failure");
        }

        [HttpGet("GetAllCases")]
        public IActionResult GetAllCases()
        {
            var cases = _caseRepository.GetAllCases();
            if (cases != null)
            {
                return Ok(cases);
            }

            return NotFound();
        }

        [HttpGet("GetActiveCases")]
        public IActionResult GetActiveCases()
        {
            var cases = _caseRepository.GetActiveCases();
            if (cases != null)
            {
                return Ok(cases);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetCase(int id)
        {
            var mycase = _caseRepository.GetById(id);

            if (mycase == null)
            {
                return NotFound();
            }

            return Ok(mycase);
        }

        [HttpPut("EditCase")]
        public IActionResult Edit([FromBody] Case mycase)
        {
            _caseRepository.UpdateCase(mycase);

            return Ok(mycase);
        }
    }
}