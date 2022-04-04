using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Interfaces
{
    public interface ICalificacionData
    {
        List<Calificacion> Obtener(int evaluacion);
    }
}
