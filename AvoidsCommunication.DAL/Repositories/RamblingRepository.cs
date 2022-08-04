using AvoidsCommunication.DAL.Interfaces;
using AvoidsCommunication.Domain.Entity;

namespace AvoidsCommunication.DAL.Repositories
{
    public class RamblingRepository : IBaseRepository<Rambling>
    {
        private readonly ApplicationDbContext _context;

        public RamblingRepository(ApplicationDbContext
            context)
        {
            _context = context;
        }

        public async Task Create(Rambling entity)
        {
            await _context.Ramblings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Rambling entity)
        {
            _context.Ramblings.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Rambling> GetAll()
        {
            return _context.Ramblings;
        }

        public async Task<Rambling> Update(Rambling entity)
        {
            _context.Ramblings.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
