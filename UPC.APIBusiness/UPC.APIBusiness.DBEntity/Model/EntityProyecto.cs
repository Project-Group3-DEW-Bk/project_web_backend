using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityProyecto : EntityBase
    {
        public int codproyecto { get; set; }
        public string nombreproyecto { get; set; }
        public int codestado { get; set; }
        public string soporte { get; set; }
        public string coordinador { get; set; }
        public int codsector { get; set; }
        public string direccion { get; set; }
        public string observacion { get; set; }
        public int codtipo { get; set; }
        public List<EntityAplicativo> aplicativos   { get; set; }


    }
}
