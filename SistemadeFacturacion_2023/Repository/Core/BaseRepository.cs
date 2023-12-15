using Microsoft.EntityFrameworkCore;
using SistemadeFacturacion_2023.Context;
using System.Linq.Expressions;

namespace SistemadeFacturacion_2023.Repository.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly FacturaContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(FacturaContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public bool Exists(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<T> GetEntities()
        {
            return _dbSet.ToList();
        }

        public virtual T GetEntityByID(int ID)
        {
            return _dbSet.Find(ID);
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Save(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
