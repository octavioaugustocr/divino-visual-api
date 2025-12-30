using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace divino_visual_api.Models
{
    public sealed class AddressSalonModel
    {
        public string? Cep { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public char? UF { get; set; }
    }
}