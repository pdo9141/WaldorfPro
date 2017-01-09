using System.Collections.Generic;
using Waldorf.Domain.Enums;
using Waldorf.Common.ExtensionMethods;

namespace Waldorf.Web.ViewModels.Colleague
{
    public class JobPositionOfInterestViewModel
    {
        public JobPositionOfInterestViewModel()
        {
            Categories = new List<JobPositionTierOneCategoryViewModel>();
        }

        public JobPositionType JobPositionType { get; set; }

        public int Id { get { return (int)JobPositionType; } }

        public string DisplayName { get { return JobPositionType.GetDisplayName(); } }

        public bool Selected { get; set; }

        public List<JobPositionTierOneCategoryViewModel> Categories { get; set; }
    }

    public class JobPositionTierOneCategoryViewModel
    {
        public JobPositionTierOneCategoryViewModel()
        {
            Categories = new List<JobPositionTierTwoCategoryViewModel>();
        }

        public JobPositionTierOneCategoryType JobPositionTierOneCategoryType { get; set; }        

        public int Id { get { return (int)JobPositionTierOneCategoryType; } }

        public string DisplayName { get { return JobPositionTierOneCategoryType.GetDisplayName(); } }

        public bool Selected { get; set; }

        public List<JobPositionTierTwoCategoryViewModel> Categories { get; set; }
    }

    public class JobPositionTierTwoCategoryViewModel
    {
        public JobPositionTierTwoCategoryType JobPositionTierTwoCategoryType { get; set; }

        public int Id { get { return (int)JobPositionTierTwoCategoryType; } }

        public string DisplayName { get { return JobPositionTierTwoCategoryType.GetDisplayName(); } }

        public bool Selected { get; set; }
    }
}