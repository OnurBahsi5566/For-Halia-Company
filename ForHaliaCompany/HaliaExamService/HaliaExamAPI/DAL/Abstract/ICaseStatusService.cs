using HaliaExamAPI.Models;
using HaliaExamAPI.Models.TempModel;
using System.Collections.Generic;

namespace HaliaExamAPI.DAL.Abstract
{
    public interface ICaseStatusService
    {

        CaseStatus Insert(AssignedCaseAnswer assignedCaseAnswer,int sessionUserId);

        void UpdateCase(int id, string status);

        void UpdateAssignedCase(int id, string status);

        List<TempCaseStatus> GetByCaseId(int caseId);
    }
}