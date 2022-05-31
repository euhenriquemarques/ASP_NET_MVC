using ProjetoHenrique.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoHenrique.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {

        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
    }
}
