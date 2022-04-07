using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Modelos
{
    public class StatusResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
    }
}
