using System;

namespace HaliaExamAPI.Models.TempModel
{
    public class TempCase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public string Status { get; set; }

        public string StatusDescription { get; set; }

        public string AssignedUser { get; set; }

        public string OpenedUser { get; set; }
    }
}
