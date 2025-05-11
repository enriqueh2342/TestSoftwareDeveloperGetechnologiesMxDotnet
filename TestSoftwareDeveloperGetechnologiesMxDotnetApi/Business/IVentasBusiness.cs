using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Schemas;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Business
{
    public interface IVentasBusiness
    {
        Task<IEnumerable<Bill>> findBillsByPersonAsync(string identificationPersona);
        Task<GenericResponse> storeBillAsync(Bill bill, string identificationPerson);
    }
}
