using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Repository;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Schemas;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Business
{
    public class DirectoryBusiness : IDirectoryBusiness
    {
        private IPersonRepository _personRepository;
        public DirectoryBusiness(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<GenericResponse> findPersonByIdentification(string identification)
        {
            var personFound = await _personRepository.findPersonByIdentification(identification);
            if (personFound == null)
            {
                return new GenericResponse
                {
                    Code = System.Net.HttpStatusCode.NotFound,
                    Message = "Persona no encontrada",
                    Data = null
                };
            }
            return new GenericResponse
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "OK",
                Data = personFound
            }; 
        }

        public async Task<IEnumerable<Person>> getAllPersons()
        {
            return await _personRepository.getAllPersons();
        }
    }
}
