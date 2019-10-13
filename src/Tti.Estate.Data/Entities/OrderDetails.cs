using System;
using System.Collections.Generic;
using System.Text;

namespace Tti.Estate.Data.Entities
{
   public class OrderDetails :BaseEntity
    {

          public string observaciones { set; get; }
          public List<Articulo> articulo { set; get; }

          public double cantidadMetrosSolicitados { set; get; }
          
    }
}
