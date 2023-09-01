using HaliaExamAPI.DAL.Abstract;
using HaliaExamAPI.Models;
using HaliaExamAPI.Models.TempModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaliaExamAPI.DAL.Concrate
{
    public class CaseStatusRepository : ICaseStatusService
    {
        private Context _context;
        
        public CaseStatusRepository(Context context)
        {
            _context = context;
        }

        public List<TempCaseStatus> GetByCaseId(int caseId)
        {
            var result = from cs in _context.casesstatus.ToList()
                         join c in _context.cases.ToList()
                         on cs.caseid equals c.id
                         join u in _context.users.ToList()
                         on cs.actioneduserid equals u.id
                         where cs.caseid == caseId
                         select new
                         {
                             cs.id,
                             c.name,
                             cs.date,
                             cs.status,
                             cs.statusdescription,
                             ActionedUser =  u.firstname + ' ' + u.lastname
                         };

            List<TempCaseStatus> listtempCaseStatuses = new List<TempCaseStatus>();
            TempCaseStatus tempCaseStatus;

            foreach (var item in result)
            {
                tempCaseStatus = new TempCaseStatus();
                tempCaseStatus.Id = item.id;
                tempCaseStatus.CaseName = item.name;
                tempCaseStatus.Date = item.date;
                tempCaseStatus.Status = item.status;
                tempCaseStatus.StatusDescription = item.statusdescription;
                tempCaseStatus.ActionedUser = item.ActionedUser;

                listtempCaseStatuses.Add(tempCaseStatus);
            }

            return listtempCaseStatuses;
        }

        public CaseStatus Insert(AssignedCaseAnswer assignedCaseAnswer, int sessionUserId)
        {
            CaseStatus caseStatus = new CaseStatus();

            caseStatus.caseid = assignedCaseAnswer.CaseId;
            caseStatus.date = DateTime.Now;
            caseStatus.status = assignedCaseAnswer.Status;
            caseStatus.statusdescription = assignedCaseAnswer.StatusDescription;
            caseStatus.actioneduserid = sessionUserId;

            _context.Add(caseStatus);
            _context.SaveChanges();

            return caseStatus;
        }

        public void UpdateAssignedCase(int id,string status)
        {
            var assignedCase = _context.assignedcases.Where(c => c.id == id).FirstOrDefault();
            if (assignedCase != null)
            {
                assignedCase.status = status;
                _context.assignedcases.Update(assignedCase);
                _context.SaveChanges();
            }
        }

        public void UpdateCase(int id,string status)
        {
            var mycase = _context.cases.Where(c => c.id == id).FirstOrDefault();
            if (mycase != null)
            {
                mycase.status = status;
                _context.cases.Update(mycase);
                _context.SaveChanges();
            }
        }
    }
}