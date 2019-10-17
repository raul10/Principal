using System;
using System.ComponentModel.DataAnnotations;

namespace Tti.Estate.Web.Models
{
    public class OrderListCriteriaModel
    {
        public OrderListCriteriaModel()
        {
        }
        [Display(Name = "User")]
        public long? UserId { get; set; }

        [Display(Name = "Id")]
        public long? Id { get; set; }

        [Display(Name = "Term")]
        public string Term { get; set; }

        [Display(Name = "Codigo Pedido")]
        public string CodigoPedido { get; set; }

        [Display(Name = "Tienda")]
       public string Tienda { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Display(Name = "Fecha Pedido")]
      public DateTime? FecPedido { get; set; }


        [Display(Name = "Observaciones")]
      public string Observaciones { get; set; }

        [Display(Name = "Prioridad")]
        public int? Prioridad { get; set; }


    }



}
