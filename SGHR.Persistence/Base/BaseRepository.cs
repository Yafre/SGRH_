using Microsoft.EntityFrameworkCore;
using SGHR.Domain.Base;
using SGHR.Domain.Repository;
using SGHR.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGHR.Persistence.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly SGHRContext _context;

        public BaseRepository(SGHRContext context)
        {
            _context = context;
        }

        public virtual async Task<OperationResult> AddAsync(T entity)
        {
            var result = new OperationResult();
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error al agregar: {ex.Message}";
            }
            return result;
        }

        public virtual async Task<OperationResult> UpdateAsync(T entity)
        {
            var result = new OperationResult();
            try
            {
                _context.Set<T>().Update(entity);
                await SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error al actualizar: {ex.Message}";
            }
            return result;
        }

        public virtual async Task<OperationResult> DeleteAsync(int id)
        {
            var result = new OperationResult();
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el registro.";
                    return result;
                }

                _context.Set<T>().Remove(entity);
                await SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error al eliminar: {ex.Message}";
            }
            return result;
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().AnyAsync(filter);
        }

        public virtual async Task<T?> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar cambios: {ex.Message}");
            }
        }
    }
}
