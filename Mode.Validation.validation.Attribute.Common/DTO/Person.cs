using Mode.Validation.validation.Attribute.Common.Attributes;
using Mode.Validation.validation.Attribute.Common.Enum;

namespace Mode.Validation.validation.Attribute.Common.DTO
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        [ValidateMaritalStatus]
        public MaritalStatus MaritalStatus { get; set; }
        public string SpouseFirstName { get; set; }
        public string SpouseLastName { get; set; }
    }
}
