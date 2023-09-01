using HaliaExamAPI.DAL.Abstract;
using HaliaExamAPI.Models;
using HaliaExamAPI.Models.TempModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaliaExamAPI.DAL.Concrate
{
    public class AssignedCaseRepository : IAssignedCaseService
    {
        private readonly Context _context;

        public AssignedCaseRepository(Context context)
        {
            _context = context;
        }

        public AssignedCaseAnswer GetAssignedCaseAnswer(int id)
        {
            var result = from ac in _context.assignedcases.ToList()
                         join c in _context.cases.ToList()
                         on ac.caseid equals c.id
                         where ac.id == id
                         select new
                         {
                             ac.id,
                             CaseName = c.name,
                             ac.caseid
                         };

            AssignedCaseAnswer assignedCaseAnswer = new AssignedCaseAnswer(); 

            foreach (var item in result)
            {
                assignedCaseAnswer.Id = item.id;
                assignedCaseAnswer.CaseName = item.CaseName;
                assignedCaseAnswer.CaseId = item.caseid;
            }

            return assignedCaseAnswer;
        }

        public Case GetCaseById(int caseId)
        {
            return _context.cases.Where(c => c.id == caseId).FirstOrDefault();
        }

        public AssignedCase Insert(AssignedCase assignedCase)
        {
            _context.assignedcases.Add(assignedCase);
            _context.SaveChanges();
            return assignedCase;
        }

        public void InsertCaseStatus(int caseId, int sessionUserId)
        {
            var caseStatus = new CaseStatus();
            caseStatus.caseid = caseId;
            caseStatus.date = DateTime.Now;
            caseStatus.status = "Assigned";
            caseStatus.actioneduserid = sessionUserId;

            _context.casesstatus.Add(caseStatus);
            _context.SaveChanges();
        }

        public void UpdateCase(int caseId)
        {
            Case mycase = GetCaseById(caseId);
            mycase.status = "Assigned";
            _context.cases.Update(mycase);
            _context.SaveChanges();
        }

        public List<TempAssignedCase> userAssignedCasesList(int sessionUserId)
        {
            var result = from ac in _context.assignedcases.ToList()
                         join c in _context.cases.ToList()
                         on ac.caseid equals c.id
                         join u in _context.users.ToList()
                         on ac.actioneduserid equals u.id
                         where ac.assigneduserid == sessionUserId && ac.status == "Assigned"
                         select new
                         {
                             ac.id,
                             CaseName = c.name,
                             ActionedUserName = u.firstname + " " + u.lastname,
                             ac.description,
                         };

            List<TempAssignedCase> listUserAssignedCases = new List<TempAssignedCase>();
            TempAssignedCase tempAssignedCase;

            foreach (var item in result)
            {
                tempAssignedCase = new TempAssignedCase();
                tempAssignedCase.Id = item.id;
                tempAssignedCase.CaseName = item.CaseName;
                tempAssignedCase.ActionedUserName = item.ActionedUserName;
                tempAssignedCase.Description = item.description;
                listUserAssignedCases.Add(tempAssignedCase);
            }

            return listUserAssignedCases;
        }
    }
}