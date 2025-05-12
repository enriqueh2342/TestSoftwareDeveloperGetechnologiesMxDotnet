using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Schemas;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Repository
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Bill>> findBillsByPersonAsync(string identificationPersona);
        Task<int> storeBillAsync(DTOBill bill, int IdPerson);
    }
}
