using System;
using System.ComponentModel.DataAnnotations;

namespace BMP280API.Models
{
    public class ModuleData
    {
        [Key]
        public Guid Guid { get; set; }
        
        public double? Longitude { get; set; }
        
        public double? Latitude { get; set; }
        
        public float Temperature { get; set; }
        
        public int Pression { get; set; }
        
        public DateTime DateTime { get; set; }
        
        public Guid ModuleGuid { get; set; }
    }
}