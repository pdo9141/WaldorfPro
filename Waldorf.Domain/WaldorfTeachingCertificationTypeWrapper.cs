using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class WaldorfTeachingCertificationTypeWrapper
    {
        public long Id { get; set; }

        public long PartyId { get; set; }

        public WaldorfTeachingCertificationType WaldorfTeachingCertificationType { get; set; }
        
        public static implicit operator WaldorfTeachingCertificationType(WaldorfTeachingCertificationTypeWrapper val)
        {
            return val.WaldorfTeachingCertificationType;
        }

        public static implicit operator WaldorfTeachingCertificationTypeWrapper(WaldorfTeachingCertificationType val)
        {
            return new WaldorfTeachingCertificationTypeWrapper { WaldorfTeachingCertificationType = val };
        }
    }
}
