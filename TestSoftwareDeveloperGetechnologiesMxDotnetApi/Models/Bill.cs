using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models
{
    public class Bill : AuditFields
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float Amount { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        //[ForeignKey("Person")]
        //public string PersonIdentification { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
    }
}
