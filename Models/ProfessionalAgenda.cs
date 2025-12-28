using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace divino_visual_api.Models
{
    public class ProfessionalAgenda
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int LunchBreakDurationMinutes { get; set; }
        public TimeOnly LunchBreakStart { get; set; }
        public TimeOnly LunchBreakEnd { get; set; }
        public int ProfessionalId { get; set; }
    }
}