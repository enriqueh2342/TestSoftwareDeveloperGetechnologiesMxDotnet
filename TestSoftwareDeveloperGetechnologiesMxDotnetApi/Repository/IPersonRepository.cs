using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> findPersonasAsync();
        Task<Person?> findPersonByIdentificationAsync(string identification);
        Task<int> storePersonAsync(Person person);
        Task<bool> deletePersonByIdentificationAsync(string identification);
        Task<Person?> findPersonByIdAsync(int IdPerson);
    }
}
