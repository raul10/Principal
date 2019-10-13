using System;
using System.Collections.Generic;
using System.Text;

namespace Tti.Estate.Data.Entities
{
   public class Order:BaseEntity
        
    {
        public string numeroPedido { set; get; } 
        public string tiendaPedido { set; get; }
        public DateTime fecPedido { set; get; }
        public string estado { set; get; }
        public DateTime fecEntrega { set; get; }
        public string Observaciones { set; get; }

        public string usuarioModifica { set; get; }

        public OrderDetails detalleOrden { set; get; }

        public int prioridad { set; get; }



    }
}
