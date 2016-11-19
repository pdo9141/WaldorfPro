using Waldorf.Domain.Enums;

namespace Waldorf.Domain
{
    public class SchoolDescriptionTypeWrapper
    {
        public int Id { get; set; }

        public SchoolDescriptionType SchoolDescriptionType { get; set; }

        public int SchoolId { get; set; }

        public static implicit operator SchoolDescriptionType(SchoolDescriptionTypeWrapper val)
        {
            return val.SchoolDescriptionType;
        }

        public static implicit operator SchoolDescriptionTypeWrapper(SchoolDescriptionType val)
        {
            return new SchoolDescriptionTypeWrapper { SchoolDescriptionType = val };
        }
    }
}
