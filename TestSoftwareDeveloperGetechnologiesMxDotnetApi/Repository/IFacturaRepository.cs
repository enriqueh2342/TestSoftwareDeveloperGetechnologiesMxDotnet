using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Repository
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Bill>> findBillsByPersonAsync(string identificationPersona);
        Task<int> storeBillAsync(Bill bill);
    }
}
