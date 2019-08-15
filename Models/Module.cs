using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BMP280API.Models
{
    public class Module
    {
        [Key]
        public Guid Guid { get; set; }
        
        public string Name { get; set; }
        
        public string Country { get; set; }
        
        public string City { get; set; }
        
        public string Address { get; set; }
        
        [NotMapped]
        public string CompleteAddress => $"{Address}, {City}, {Country}";

        [JsonIgnore]
        public ICollection<ModuleData> ModuleDatas { get; set; }
    }
}