using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IRolUsuarioRepository
    {
        EntityBaseResponse GetRolUsuario();
        EntityBaseResponse InsertarRolUsuario(EntityRolUsuario rolusuario);
    }
}
