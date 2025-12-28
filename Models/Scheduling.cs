using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using divino_visual_api.Enums;

namespace divino_visual_api.Models
{
    public class Scheduling
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SalonId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public DateTime SchedulingDate { get; set; }
        public SchedulingStatsEnum Stats { get; set; }
        public decimal TotalValue { get; set; }
        public string? Observations { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}