using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace divino_visual_api.Models
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Stats { get; set; } = true;
    }
}