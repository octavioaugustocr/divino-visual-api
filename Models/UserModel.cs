using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using divino_visual_api.Enums;

namespace divino_visual_api.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DateBirth { get; set; }
        public GenrerEnum Genrer { get; set; }
        public string? ProfilePhoto { get; set; }
        public TypeUserEnum TypeUser { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}