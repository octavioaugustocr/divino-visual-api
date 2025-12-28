using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace divino_visual_api.Models
{
    public class ServiceProfessional
    {
        public int Id { get; set; }
        public int ProfessionalId { get; set; }
        public int ServiceId { get; set; }
    }
}