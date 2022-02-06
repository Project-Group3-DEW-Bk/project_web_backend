using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityAplicativo : EntityBase
    {
        public int codaplicativo { get; set; }
        public string nombreaplicativo { get; set; }
        public string tipouso { get; set; }
        public int codtipoapp { get; set; }
        public int codproyecto { get; set; }
    }
}
