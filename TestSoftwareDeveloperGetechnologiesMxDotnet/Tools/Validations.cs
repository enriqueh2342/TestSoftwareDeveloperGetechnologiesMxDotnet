using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSoftwareDeveloperGetechnologiesMxDotnet.Models;

namespace TestSoftwareDeveloperGetechnologiesMxDotnet.Tools
{
    public class Validations
    {
        public (bool isvalid, string message) ValidateModel(Person person)
        {
            if (string.IsNullOrEmpty(person.Name))
                return (false, "Ingrese el nombre");

            if (string.IsNullOrEmpty(person.MiddleName))
                return (false, "Ingrese el Apellido Paterno");

            if (string.IsNullOrEmpty(person.Identification))
                return (false, "Ingrese su Curp");

            return (true, string.Empty);
        }
    }
}
