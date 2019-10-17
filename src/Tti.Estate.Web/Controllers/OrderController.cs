using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tti.Estate.Business.Exceptions;
using Tti.Estate.Business.Services;
using Tti.Estate.Data.Entities;
using Tti.Estate.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tti.Estate.Web.Controllers
{

    [Authorize(Policy = PolicyConstants.UserManagement)]
    public class OrderController : Controller
    {
        // GET: /<controller>/
        private readonly IMapper _mapper;
        private readonly IOrderService  _orderService;


        public OrderController(IOrderService order,IMapper mapper)
        {
            _orderService = order ?? throw new ArgumentNullException(nameof(order));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult>  Index(OrderListCriteriaModel  criteria, int pageIndex = 0, int pageSize = 20)
        {
            var order = await _orderService .ListAsync(pageIndex: pageIndex, pageSize: pageSize,
                userId: criteria.UserId, numeroPedido:criteria. CodigoPedido, tiendaPedido:criteria.Tienda
            );
            var model = new OrderLisModel()
            {
                //(criteria.UserId.HasValue || !string.IsNullOrEmpty(criteria.Term)) ? criteria : null,
                Criteria = (criteria.UserId.HasValue || !string.IsNullOrEmpty(criteria.Term) || !string.IsNullOrEmpty(criteria.CodigoPedido) || !string.IsNullOrEmpty(criteria.Observaciones)) ? criteria : null,
                Orders = _mapper.Map<PagedResultModel<OrderListItemModel>>(order),
            };
              return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.Map<Order>(model);

                await _orderService.CreateAsync(order);

                return RedirectToAction("Details", new { id = order.Id });
            }

            await PrepareModelAsync(model);

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            OrderModel model = new OrderModel();
            await PrepareModelAsync(model);
            return View();
        }

        private async Task PrepareModelAsync(OrderModel  model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //model.Users = _mapper.Map<IEnumerable<SelectListItem>>(await _userRepository.ListAsync(new UserFilterSpecification(onlyActive: true)));
        }



    }
}
