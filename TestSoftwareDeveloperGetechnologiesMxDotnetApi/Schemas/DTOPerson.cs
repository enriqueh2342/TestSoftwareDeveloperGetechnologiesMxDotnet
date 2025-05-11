using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Schemas
{
    public class DTOPerson
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}
