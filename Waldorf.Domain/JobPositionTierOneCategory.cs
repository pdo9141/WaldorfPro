using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class JobPositionTierOneCategory
    {
        public long Id { get; set; }

        public JobPositionTierOneCategoryType JobPositionTierOneCategoryType { get; set; }
        
        public JobPositionTierTwoCategory JobPositionTierTwoCategory { get; set; }
    }
}
