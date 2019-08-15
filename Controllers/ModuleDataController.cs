using System.Threading.Tasks;
using BMP280API.Models;
using BMP280API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BMP280API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleDataController : ControllerBase
    {
        private readonly ModuleDataService _moduleDataService;

        public ModuleDataController(ModuleDataService moduleDataService)
        {
            _moduleDataService = moduleDataService;
        }

        [HttpPost]
        public async Task<ActionResult<ModuleData>> PostModule(ModuleData moduleData)
        {
            await _moduleDataService.CreateAsync(moduleData);

            return moduleData;
        }
    }
}