using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IAplicativoRepository
    {
        EntityBaseResponse GetAplicativo(int id);
        EntityBaseResponse GetAplicativos();
        EntityBaseResponse InsertarAplicativo(EntityAplicativo aplicativo);
    }
}
