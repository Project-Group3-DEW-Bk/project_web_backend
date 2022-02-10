using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IProyectoRepository
    {
        EntityBaseResponse GetProyectos();
        EntityBaseResponse GetProyecto(int id);
        EntityBaseResponse InsertarProyecto(EntityProyecto proyecto);
    }
}
