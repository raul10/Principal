using System;
using System.Collections.Generic;
using System.Text;

namespace Tti.Estate.Data.Entities
{
    public class Articulo : BaseEntity
    {
        public string codigoArticulo { set; get; }
        public string nombreArticulo { set; get; }
        public TipoArticulo tipo { set; get; }

        public Color colorArticulo { get; set; }
        public double cantidadMetros { get; set; }

        public double cantidadDisponible { get; set; }
    }
}
