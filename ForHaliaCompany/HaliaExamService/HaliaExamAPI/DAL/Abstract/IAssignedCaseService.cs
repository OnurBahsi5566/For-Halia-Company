using HaliaExamAPI.Models;
using HaliaExamAPI.Models.TempModel;
using System.Collections.Generic;

namespace HaliaExamAPI.DAL.Abstract
{
    public interface IAssignedCaseService
    {

        AssignedCase Insert(AssignedCase assignedCase);

        void InsertCaseStatus(int caseId, int sessionUserId);

        Case GetCaseById(int caseId);

        void UpdateCase(int caseId);

        List<TempAssignedCase> userAssignedCasesList(int sessionUserId);

        AssignedCaseAnswer GetAssignedCaseAnswer(int id);
    }
}
