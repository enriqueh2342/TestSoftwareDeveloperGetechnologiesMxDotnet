using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Repository;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Schemas;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Business
{
    public class VentasBusiness : IVentasBusiness
    {
        
        private IPersonRepository _personrepository;
        private IFacturaRepository _facturaRepository;
        public VentasBusiness(IFacturaRepository facturaRepository, IPersonRepository personrepository)
        {
            _facturaRepository = facturaRepository;
            _personrepository = personrepository;

        }
        public async Task<IEnumerable<Bill>> findBillsByPersonAsync(string identificationPersona)
        {
            var billsFound = await _facturaRepository.findBillsByPersonAsync(identificationPersona);
            return billsFound.ToList();
        }

        public async Task<GenericResponse> storeBillAsync(DTOBill bill, string identificationPerson)
        {
            var personFound = await _personrepository.findPersonByIdentificationAsync(identificationPerson);
            if (personFound == null)
            {
                return new GenericResponse
                {
                    Code = System.Net.HttpStatusCode.NotFound,
                    Message = "La persona no existe",
                    Data = null
                };
            }

            var newbillId = await _facturaRepository.storeBillAsync(bill, personFound.Id);
            if (newbillId == 0)
            {
                return new GenericResponse
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = "No se pudo guardar la factura, intente de nuevo más tarde",
                    Data = null
                };
            }

            return new GenericResponse
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Factura guardada correctamente",
                Data = newbillId
            };
        }
    }
}
