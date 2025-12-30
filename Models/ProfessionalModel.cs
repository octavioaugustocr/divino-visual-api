using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using divino_visual_api.Enums;

namespace divino_visual_api.Models
{
    public class ProfessionalModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public GenderEnum Gender { get; set; }
        public string? ProfilePhoto { get; set; }
        public bool Active { get; set; }
        public int? SalonId { get; set; }
    }
}