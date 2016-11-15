namespace Waldorf.Domain
{
    public class JobPositionTierTwoCategory
    {
        public int Id { get; set; }
        
        public JobPositionTierTwoCategoryType JobPositionTierTwoType { get; set; }

        public int JobPositionTierOneCategoryId { get; set; }
    }
}
