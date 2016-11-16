using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain
{
    public class JobPositionTierTwoCategory
    {
        public long Id { get; set; }

        public JobPositionTierTwoCategoryType JobPositionTierTwoCategoryType { get; set; }
    }
}
