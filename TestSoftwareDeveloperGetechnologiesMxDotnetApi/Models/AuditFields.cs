namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models
{
    public abstract class AuditFields
    {
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
