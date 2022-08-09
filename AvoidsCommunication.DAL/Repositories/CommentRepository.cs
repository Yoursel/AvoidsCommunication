using AvoidsCommunication.DAL.Interfaces;
using AvoidsCommunication.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AvoidsCommunication.DAL.Repositories
{
    public class CommentRepository : IBaseRepository<Comment>
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext
            context)
        {
            _context = context;
        }

        public async Task Create(Comment entity)
        {
            await _context.Comments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Comment entity)
        {
            _context.Comments.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Comment> GetAll()
        {
            return _context.Comments.Include(u=>u.User).Include(r=>r.Rambling);
        }

        public async Task<Comment> Update(Comment entity)
        {
            _context.Comments.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
