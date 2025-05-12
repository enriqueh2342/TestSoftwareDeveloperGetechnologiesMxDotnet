using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Schemas
{
    public class DTOBill
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float Amount { get; set; }
 
        //public string PersonIdentification { get; set; }
    }
}
