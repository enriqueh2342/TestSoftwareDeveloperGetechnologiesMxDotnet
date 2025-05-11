using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models
{
    public class Bill : AuditFields
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Amount { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        //[ForeignKey("Person")]
        //public string PersonIdentification { get; set; }
        public Person Person { get; set; }
    }
}
