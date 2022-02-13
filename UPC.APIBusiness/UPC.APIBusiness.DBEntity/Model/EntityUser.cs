using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUser : EntityBase
    {
        public int codusuario { get; set; } // MEJORA: Reemplazar por Key, ID - Alias BD
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        public int codrol { get; set; }
        public string desrol { get; set; }
        public string nombreusuario { get; set; }
        public string estadousuario { get; set; }

    }
}
