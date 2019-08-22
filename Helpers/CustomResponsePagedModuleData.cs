using System.Collections.Generic;
using BMP280API.Models;

namespace BMP280API.Helpers
{
    public class CustomResponseModule
    {
        public Module Module { get; set; }
        
        public CustomResponsePaged<PaginatedList<ModuleData>> ModuleDatas { get; set; }
    }
}