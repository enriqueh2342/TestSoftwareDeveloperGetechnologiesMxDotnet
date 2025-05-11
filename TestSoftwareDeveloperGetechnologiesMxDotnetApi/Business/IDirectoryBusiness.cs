using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Schemas;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Business
{
    public interface IDirectoryBusiness
    {
        Task<GenericResponse> findPersonByIdentification(string identification);
        Task<IEnumerable<Person>> getAllPersons();
    }
}
