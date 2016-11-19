using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class PartyTypeWrapper
    {        
        public long Id { get; set; }

        public PartyType PartyType { get; set; }

        public long PartyId { get; set; }

        public static implicit operator PartyType(PartyTypeWrapper val)
        {
            return val.PartyType;
        }

        public static implicit operator PartyTypeWrapper(PartyType val)
        {
            return new PartyTypeWrapper { PartyType = val };
        }
    }
}
