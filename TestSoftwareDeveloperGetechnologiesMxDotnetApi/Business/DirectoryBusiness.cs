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

        public async Task<GenericResponse> findPersonByIdentificationAsync(string identification)
        {
            var personFound = await _personRepository.findPersonByIdentificationAsync(identification);
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

        public async Task<IEnumerable<Person>> findPersonasAsync()
        {
            return await _personRepository.findPersonasAsync();
        }

        public async Task<GenericResponse> storePersonAsync(Person person)
        {
            var personFound = await _personRepository.findPersonByIdentificationAsync(person.Identification);
            if (personFound != null)
            {
                return new GenericResponse
                {
                    Code = System.Net.HttpStatusCode.Forbidden,
                    Message = "La persona ya existe",
                    Data = null
                };
            }

            var newpersonId = await _personRepository.storePersonAsync(person);
            if (newpersonId == 0)
            {
                return new GenericResponse
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = "Error al guardar",
                    Data = null
                };
            }

            return new GenericResponse
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Guardado correctamente",
                Data = newpersonId
            };

        }
        public async Task<GenericResponse> deletePersonByIdentificationAsync(string identification)
        {
            var personFound = await _personRepository.findPersonByIdentificationAsync(identification);
            if (personFound == null)
            {
                return new GenericResponse
                {
                    Code = System.Net.HttpStatusCode.NotFound,
                    Message = "No se encontró la persona",
                    Data = null
                };
            }

            var persondeleted = await _personRepository.deletePersonByIdentificationAsync(identification);
            if (!persondeleted)
            {
                return new GenericResponse
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = "No se pudo eliminar la persona",
                    Data = null
                };
            }

            return new GenericResponse
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Se eliminó la persona correctamente",
                Data = true
            };

        }

        public async Task<Person?> findPersonByIdAsync(int IdPerson)
        {
            return await _personRepository.findPersonByIdAsync(IdPerson);
        }
    }
}
