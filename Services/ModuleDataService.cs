using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMP280API.Data;
using BMP280API.Helpers;
using BMP280API.Models;
using Microsoft.EntityFrameworkCore;

namespace BMP280API.Services
{
    public class ModuleDataService
    {
        private readonly ApiContext _context;

        public ModuleDataService(ApiContext context)
        {
            _context = context;
        }

        public Task<PaginatedList<ModuleData>> GetAsync(int pageIndex, int pageSize)
        {
            return PaginatedList<ModuleData>.CreateAsync
            (
                _context.ModuleDatas.AsNoTracking(),
                pageIndex,
                pageSize
            );
        }

        public Task<ModuleData> GetAsync(Guid guid)
        {
            return _context.ModuleDatas.FindAsync(guid);
        }

        public Task<PaginatedList<ModuleData>> GetDataFromModule(Guid moduleGuid, int pageIndex, int PageSize)
        {
            return PaginatedList<ModuleData>.CreateAsync(
                _context.ModuleDatas
                    .Where(e => e.ModuleGuid == moduleGuid)
                    .OrderByDescending(e => e.DateTime),
                pageIndex, PageSize);
        }

        public Task CreateAsync(ModuleData moduleData)
        {
            _context.ModuleDatas.Add(moduleData);
            return _context.SaveChangesAsync();
        }

        public Task PutAsync(ModuleData moduleData)
        {
            _context.Entry(moduleData).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var ModuleData = await _context.ModuleDatas.FindAsync(id);
            _context.ModuleDatas.Remove(ModuleData);
        }
    }
}