namespace Modelo.Modelos
{
    public class Calificacion
    {
        public int FormatoId { get; set; }
        public int EvaluacionId { get; set; }
        public int Nota { get; set; }
        public string Observacion { get; set; }
        public bool? PlanMejora { get; set; }

    }
}
