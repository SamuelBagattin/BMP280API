using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMP280API.Data;
using BMP280API.Helpers;
using BMP280API.Models;
using BMP280API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BMP280API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly ModuleService _moduleService;
        private readonly ModuleDataService _moduleDataService;
        public ModuleController(ModuleDataService moduleDataService, ModuleService moduleService)
        {
            _moduleDataService = moduleDataService;
            _moduleService = moduleService;
        }

        // GET: api/Module
        [HttpGet]
        public async Task<ActionResult<CustomResponsePaged<PaginatedList<Module>>>> GetModules(int? pageIndex, int? pageSize)
        {
            var pageIndexResult = pageIndex ?? 1;
            var pageSizeResult = pageSize ?? 20;
            var modules = await _moduleService.GetAsync(pageIndexResult, pageSizeResult);
            modules.ForEach(e => e.LastData = e.ModuleDatas.OrderByDescending(r => r.DateTime).FirstOrDefault());
            return CustomResponsePaged<Module>.BuildFromPaginatedList(
                modules
            );
        }

        // GET: api/Module/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomResponseModule>> GetModule(Guid id, int? pageIndex, int? pageSize)
        {
            var module = await _moduleService.GetAsync(id);

            if (module == null)
            {
                return NotFound();
            }

            var datas = await _moduleDataService.GetDataFromModule(id, pageIndex ?? 1, pageSize ?? 20);
            return new CustomResponseModule
            {
                Module = module,
                ModuleDatas = new CustomResponsePaged<PaginatedList<ModuleData>>
                {
                    Result = datas,
                    PageIndex = datas.PageIndex,
                    TotalPages = datas.TotalPages,
                    HasNextPage = datas.HasNextPage,
                    HasPreviousPage = datas.HasPreviousPage
                }
            };
            
        }

        // PUT: api/Module/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(Guid id, Module @module)
        {
            if (id != @module.Guid)
            {
                return BadRequest();
            }

            try
            {
                await _moduleService.PutAsync(module);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _moduleService.AnyAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Module
        [HttpPost]
        public async Task<ActionResult<Module>> PostModule(Module @module)
        {
            await _moduleService.CreateAsync(module);

            return module;
        }

        // DELETE: api/Module/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Module>> DeleteModule(Guid id)
        {
            var @module = await _moduleService.DeleteAsync(id);
            if (@module == null)
            {
                return NotFound();
            }

            return @module;
        }
    }
}
