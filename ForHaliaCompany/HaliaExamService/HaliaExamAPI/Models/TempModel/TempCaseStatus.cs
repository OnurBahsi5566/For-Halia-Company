using System;

namespace HaliaExamAPI.Models.TempModel
{
    public class TempCaseStatus
    {
        public int Id { get; set; }

        public string CaseName { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string StatusDescription { get; set; }

        public string ActionedUser { get; set; }
    }
}
