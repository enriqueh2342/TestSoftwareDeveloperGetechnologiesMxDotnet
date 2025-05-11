using Microsoft.EntityFrameworkCore;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private AppDbContext _context;
        public PersonRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task<Person?> findPersonByIdentification(string identification)
        {
            var personfound = await _context.Persons.Include(x=>x.Bills).FirstOrDefaultAsync(x => x.Identification == identification);
            return personfound;
        }

        public async Task<IEnumerable<Person>> getAllPersons()
        {
            var persons = await _context.Persons.Include(x=>x.Bills).ToListAsync();
            return persons;
        }
    }
}
