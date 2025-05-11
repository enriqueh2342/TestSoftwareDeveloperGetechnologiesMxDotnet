using Microsoft.EntityFrameworkCore;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Commons;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;

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

        public async Task<int> storeBillAsync(Bill bill)
        {
            try
            {
                bill.CreatedBy = (int)UsersEnum.Administrator;
                bill.CreatedDate = DateTime.Now;
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
