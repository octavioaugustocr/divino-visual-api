using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace divino_visual_api.Models
{
    public class SchedulingServiceModel
    {
        public int Id { get; set; }
        public int SchedulingId { get; set; }
        public int ServiceId { get; set; }
        public decimal ServicePrice { get; set; }
        public int ServiceDurationInMinutes { get; set; }
    }
}