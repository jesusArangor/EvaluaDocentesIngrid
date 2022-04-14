using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Modelos
{
    public class RespuestaCargaEvaluacion
    {
        public int IdCarga { get; set; }
        public IEnumerable<EvaluacionTemporal> Datos { get; set; }
    }
}
