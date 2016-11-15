using System.ComponentModel.DataAnnotations;

namespace Waldorf.Domain
{
    public class PartyTypeWrapper
    {        
        [Key]
        public PartyType PartyType { get; set; }

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
