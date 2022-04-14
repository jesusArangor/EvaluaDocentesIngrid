using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Modelos
{
    public class StatusResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }
    }
}
