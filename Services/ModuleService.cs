using System;
using System.Linq;
using System.Threading.Tasks;
using BMP280API.Data;
using BMP280API.Helpers;
using BMP280API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace BMP280API.Services
{
    public class ModuleService
    {

        private readonly ApiContext _context;

        public ModuleService(ApiContext context)
        {
            _context = context;
        }

        public Task<PaginatedList<Module>> GetAsync(int pageIndex, int pageSize)
        {
            return PaginatedList<Module>.CreateAsync
                (
                    _context.Modules.AsNoTracking(),
                    pageIndex,
                    pageSize
            );
        }

        public Task<Module> GetAsync(Guid guid)
        {
            return _context.Modules.FindAsync(guid);
        }

        public Task CreateAsync(Module module)
        {
            _context.Modules.Add(module);
            return _context.SaveChangesAsync();
        }

        public Task PutAsync(Module module)
        {
            _context.Entry(module).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public async Task<Module> DeleteAsync(Guid id)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return null;
            }
            _context.Modules.Remove(module);
            return module;
        }

        public Task<bool> AnyAsync(Guid id)
        {
            return _context.Modules.AnyAsync(e => e.Guid == id);
        }
    }
}