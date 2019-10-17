using System;
using System.Threading.Tasks;
using Tti.Estate.Business.Dto;
using Tti.Estate.Data.Entities;

namespace Tti.Estate.Business.Services
{
    public interface IOrderService
    {
        
        Task CreateAsync(Order  order);
        Task<Order> GetAsync(long id);
        Task<IPagedResult<Order>> ListAsync(int pageIndex, int pageSize,
            string term = null,
            long? userId = null,
            string numeroPedido=null,
            string tiendaPedido=null,
              string estado=null,
              string Observacion=null
           );
        Task UpdateAsync(Order order);
        Task<OperationResult> DeleteAsync(long id);

    }
}
