using System.Collections.Generic;

namespace Waldorf.Web.ViewModels.Colleague
{
    public class StepTwoViewModel
    {
        public string ProfessionalName { get; set; }

        public bool IsFirstNamePreferred { get; set; }

        public string FirstName { get; set; }

        public bool IsProfessionalNamePreferred { get; set; }

        public string OtherNamePreferred { get; set; }

        public string ColleagueType { get; set; }

        public List<JobPositionOfInterestViewModel> TeacherJobPositionsOfInterest { get; set; }

        public List<JobPositionOfInterestViewModel> AdminJobPositionsOfInterest { get; set; }
    }
}