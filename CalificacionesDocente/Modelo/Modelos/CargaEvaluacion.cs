using System;
namespace Modelo.Modelos
{
    public class CargaEvaluacion
    {
        public int care_id { get; set; }
        public DateTime care_fecha { get; set; }
        public int care_usu_id { get; set; }
        public bool care_completo { get; set; }
        public int care_cantidad { get; set; }
        public string care_observacion { get; set; }
        public int care_errores { get; set; }
        public int care_semestre { get; set; }
        public int care_ano { get; set; }
        public string care_nomarchivo { get; set; }
    }
}