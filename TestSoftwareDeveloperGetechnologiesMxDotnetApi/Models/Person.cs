using System.ComponentModel.DataAnnotations;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models
{
    public class Person : AuditFields
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Identification { get; set; }

        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}
