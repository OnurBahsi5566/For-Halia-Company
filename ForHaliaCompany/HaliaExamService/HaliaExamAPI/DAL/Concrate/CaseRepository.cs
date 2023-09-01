using HaliaExamAPI.DAL.Abstract;
using HaliaExamAPI.Models;
using HaliaExamAPI.Models.TempModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace HaliaExamAPI.DAL.Concrate
{
    public class CaseRepository : ICaseService
    {
        public readonly Context _context;

        public CaseRepository(Context context)
        {
            _context = context;
        }

        public List<Case> GetActiveCases()
        {
            return _context.cases.Where(c => c.status == "Active").OrderByDescending(c => c.id).ToList();
        }

        public List<TempCase> GetAllCases()
        {
            var result = from cc in _context.cases.ToList()
                         join cs in _context.casesstatus.ToList() on cc.id equals cs.caseid into tmpCasesStatus
                         from cs in tmpCasesStatus.DefaultIfEmpty(new CaseStatus())
                         join ac in _context.assignedcases.ToList() on cc.id equals ac.caseid into tmpAssignedCases
                         from ac in tmpAssignedCases.DefaultIfEmpty(new AssignedCase())
                         join u in _context.users.ToList() on cc.openeduserid equals u.id into tmpOpenedUser
                         from u in tmpOpenedUser.DefaultIfEmpty(new User())
                         join uo in _context.users.ToList() on ac.assigneduserid equals uo.id into tmpAssignedUser
                         from uo in tmpAssignedUser.DefaultIfEmpty(new User())
                         where cc.status == cs.status
                         orderby cc.id descending
                         select new
                         {
                             cc.id,
                             cc.name,
                             cc.description,
                             cc.startdate,
                             cc.finishdate,
                             cc.status,
                             cs.statusdescription,
                             assigneduser = uo.firstname + ' ' + uo.lastname,
                             openeduser = u.firstname + ' ' + u.lastname
                         };

            List<TempCase> listTempCase = new List<TempCase>();
            TempCase tempCase;

            foreach (var item in result)
            {
                tempCase = new TempCase();
                tempCase.Id = item.id;
                tempCase.Name = item.name;
                tempCase.Description = item.description;
                tempCase.StartDate = item.startdate;
                tempCase.FinishDate = item.finishdate;
                tempCase.Status = item.status;
                tempCase.StatusDescription = item.statusdescription;
                tempCase.AssignedUser = item.assigneduser;
                tempCase.OpenedUser = item.openeduser;
                listTempCase.Add(tempCase);
            }

            return listTempCase;
        }

        public Case GetById(int id)
        {
            return _context.cases.Where(c => c.id == id).FirstOrDefault();
        }

        public Case Insert(Case myCase)
        {
            _context.cases.Add(myCase);
            _context.SaveChanges();
            return myCase;
        }

        public void InsertCaseStatus(int caseId, int sessionUserId)
        {
            var caseStatus = new CaseStatus();
            caseStatus.caseid = caseId;
            caseStatus.date = DateTime.Now;
            caseStatus.status = "Active";
            caseStatus.actioneduserid = sessionUserId;

            _context.casesstatus.Add(caseStatus);
            _context.SaveChanges();
        }

        public void UpdateCase(Case myCase)
        {
            _context.cases.Update(myCase);
            _context.SaveChanges();
        }
    }
}