﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSoftwareDeveloperGetechnologiesMxDotnet.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();

    }
}
