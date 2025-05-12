using Microsoft.EntityFrameworkCore;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Commons;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Schemas;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        private AppDbContext _context;
        public FacturaRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Bill>> findBillsByPersonAsync(string identificationPersona)
        {
            var bills = _context.Bills.Include(x=> x.Person).Where(x=>x.Person.Identification == identificationPersona).ToList();
            return bills;
        }

        public async Task<int> storeBillAsync(DTOBill dtobill, int IdPerson)
        {
            Bill bill = new Bill();
            try
            {
                bill.CreatedBy = (int)UsersEnum.Administrator;
                bill.CreatedDate = DateTime.Now;
                bill.Amount = dtobill.Amount;
                bill.Date = dtobill.Date;
                bill.PersonId = IdPerson;
                _context.Bills.Add(bill);
                await _context.SaveChangesAsync();
                return bill.Id;
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
