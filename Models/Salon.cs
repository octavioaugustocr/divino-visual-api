using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace divino_visual_api.Models
{
    public class Salon
    {
        public int Id { get; set; }
        public string FantasyName { get; set; }
        public string Cnpj { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? LogoImage { get; set; }
        public string? CoverImage { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }
        public AddressSalon Address { get; set; }
        public bool Active { get; set; }
        public int UserAdminId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}