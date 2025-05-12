using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestSoftwareDeveloperGetechnologiesMxDotnet.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public int PersonId { get; set; }
        //public ICollection<Person> Persons { get; set; }
    }
}
