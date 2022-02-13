using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IEstadoProyectoRepository
    {
        EntityBaseResponse GetEstadoProyecto();
        EntityBaseResponse InsertarEstadoProyecto(EntityEstadoProyecto estadoproyecto);
    }
}
