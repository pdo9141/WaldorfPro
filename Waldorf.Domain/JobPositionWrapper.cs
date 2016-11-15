using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain
{
    public class JobPositionWrapper
    {
        [Key]
        public JobPositionType JobPositionType { get; set; }

        public ICollection<JobPositionTierOneCategory> JobPositionTierOneCategories { get; set; }

        public static implicit operator JobPositionType(JobPositionWrapper val)
        {
            return val.JobPositionType;
        }

        public static implicit operator JobPositionWrapper(JobPositionType val)
        {
            return new JobPositionWrapper { JobPositionType = val };
        }
    }
}
