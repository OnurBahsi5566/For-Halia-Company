using HaliaExamAPI.Models;
using HaliaExamAPI.Models.TempModel;
using System.Collections.Generic;

namespace HaliaExamAPI.DAL.Abstract
{
    public interface ICaseService
    {
        Case Insert(Case myCase);

        void InsertCaseStatus(int caseId,int sessionUserId);

        List<TempCase> GetAllCases();

        List<Case> GetActiveCases();

        Case GetById(int id);

        void UpdateCase(Case myCase);
    }
}