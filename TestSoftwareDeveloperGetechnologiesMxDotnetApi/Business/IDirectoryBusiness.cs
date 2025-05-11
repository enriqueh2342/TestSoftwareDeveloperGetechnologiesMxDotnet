using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Schemas;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Business
{
    public interface IDirectoryBusiness
    {
        Task<GenericResponse> findPersonByIdentificationAsync(string identification);
        Task<IEnumerable<Person>> findPersonasAsync();
        Task<GenericResponse> storePersonAsync(Person person);
        Task<GenericResponse> deletePersonByIdentificationAsync(string identification);
        Task<Person?> findPersonByIdAsync(int IdPerson);
    }
}
