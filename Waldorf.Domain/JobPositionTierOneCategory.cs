using System.Collections.Generic;

namespace Waldorf.Domain
{
    public class JobPositionTierOneCategory
    {
        public int Id { get; set; }
        
        public JobPositionTierOneCategoryType JobPositionTierOneType { get; set; }

        public JobPositionType JobPositionType { get; set; }

        public ICollection<JobPositionTierTwoCategory> JobPositionTierTwoCategories { get; set; }
    }
}
