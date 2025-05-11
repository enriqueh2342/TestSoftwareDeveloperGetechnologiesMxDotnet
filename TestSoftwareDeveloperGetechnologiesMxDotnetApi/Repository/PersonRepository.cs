using Microsoft.EntityFrameworkCore;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Schemas;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Commons;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private AppDbContext _context;
        public PersonRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Person>> findPersonasAsync()
        {
            var persons = await _context.Persons.Include(x => x.Bills).ToListAsync();
            return persons;
        }
        public async Task<Person?> findPersonByIdentificationAsync(string identification)
        {
            var personfound = await _context.Persons.Include(x=>x.Bills).FirstOrDefaultAsync(x => x.Identification == identification);
            return personfound;
        }

        public async Task<Person?> findPersonByIdAsync(int IdPerson)
        {
            var personfound = await _context.Persons.FirstOrDefaultAsync(x => x.Id == IdPerson);
            return personfound;
        }


        public async Task<int> storePersonAsync(Person person)
        {
            try
            {
                person.CreatedBy = (int)UsersEnum.Administrator;
                person.CreatedDate = DateTime.Now;
                _context.Persons.Add(person);
                await _context.SaveChangesAsync();
                return person.Id;
            }
            catch (Exception)
            {

                return 0;
            }
          
        }

        public async Task<bool> deletePersonByIdentificationAsync(string identification)
        {
            try
            {
                var personFound =await  _context.Persons.FirstOrDefaultAsync(x=>x.Identification == identification);
                _context.Persons.Remove(personFound);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
