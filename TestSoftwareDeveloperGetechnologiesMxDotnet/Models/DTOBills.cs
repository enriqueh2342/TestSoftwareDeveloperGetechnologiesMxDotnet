using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSoftwareDeveloperGetechnologiesMxDotnet.Models
{
    public class DTOBills
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string PersonFullName { get; set; }
        public string PersonIdentification { get; set; }
    }
}
