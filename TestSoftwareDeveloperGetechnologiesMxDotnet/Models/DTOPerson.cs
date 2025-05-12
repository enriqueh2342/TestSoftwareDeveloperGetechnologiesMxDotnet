using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSoftwareDeveloperGetechnologiesMxDotnet.Models
{
    public class DTOPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? BillsCount { get; set; }
        public float? Amount { get; set; }
        public string Identification { get; set; }
        public DateTime? LastBillDate { get; set; }


    }
}
