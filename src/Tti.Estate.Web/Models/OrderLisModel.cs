using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tti.Estate.Web.Models
{
    public class OrderLisModel
    {
        public OrderListCriteriaModel Criteria { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }

        public PagedResultModel<OrderListItemModel> Orders { get; set; }


    }
}
