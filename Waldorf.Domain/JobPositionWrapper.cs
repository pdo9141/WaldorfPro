using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain
{
    public class JobPositionWrapper
    {
        public long Id { get; set; }

        public JobPositionType JobPositionType { get; set; }

        public long PartyId { get; set; }

        public JobPositionTierOneCategory JobPositionTierOneCategory { get; set; }

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
