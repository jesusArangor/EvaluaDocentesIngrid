using System.Collections.Generic;

namespace Modelo.Modelos
{
    public class RespuestaCargaDocente
    {
        public int IdCarga { get; set; }
        public IEnumerable<DocenteTemporal> Datos { get; set; }
    }
}
