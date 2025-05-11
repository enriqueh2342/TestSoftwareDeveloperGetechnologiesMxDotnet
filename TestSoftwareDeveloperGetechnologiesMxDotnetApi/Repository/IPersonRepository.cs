using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Repository
{
    public interface IPersonRepository
    {
        Task<Person?> findPersonByIdentification(string identification);
        Task<IEnumerable<Person>> getAllPersons();
    }
}
