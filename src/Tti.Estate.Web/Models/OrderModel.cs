using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tti.Estate.Web.Models
{
    public class OrderModel
    {

        [Display(Name = "Tienda")]
        [Required(ErrorMessage = "Requerido")]
        [StringLength(256)]
        public string Tienda { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Display(Name = "Fecha Pedido")]
        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        public DateTime? FecPedido { get; set; }


        [Display(Name = "Observaciones")]
        [Required(ErrorMessage = "Required")]
        [StringLength(maximumLength:100)]
        public string Observaciones { get; set; }

        [Display(Name = "Prioridad")]
        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        public int? Prioridad { get; set; }



    }
}
