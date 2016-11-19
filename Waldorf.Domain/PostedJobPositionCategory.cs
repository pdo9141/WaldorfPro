using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class PostedJobPositionCategory
    {
        public long Id { get; set; }

        public JobPositionType JobPositionType { get; set; }
        
        public JobPositionTierOneCategory JobPositionTierOneCategory { get; set; }

        public static implicit operator JobPositionType(PostedJobPositionCategory val)
        {
            return val.JobPositionType;
        }

        public static implicit operator PostedJobPositionCategory(JobPositionType val)
        {
            return new PostedJobPositionCategory { JobPositionType = val };
        }
    }
}
