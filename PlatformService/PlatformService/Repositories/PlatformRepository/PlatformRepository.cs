using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Entities;


namespace PlatformService.Repositories.PlatformRepository
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _context;

        public PlatformRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Platform entity)
        {

             await _context.Platforms.AddAsync(entity);
             await _context.SaveChangesAsync();
        }

        public async Task Delete(Platform entity)
        {
            _context.Platforms.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Platform>> GetAll()
        {
            return await _context.Platforms.ToListAsync();
        }

        public async Task<Platform> GetById(int id)
        {
            return await _context.Platforms.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Platform entity)
        {
             _context.Platforms.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
