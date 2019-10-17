using System;
using System.Threading.Tasks;
using Tti.Estate.Business.Dto;
using Tti.Estate.Data.Entities;

namespace Tti.Estate.Business.Services
{
    public class OrderService:IOrderService
    {
        public OrderService()
        {
        }

        public Task CreateAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedResult<Order>> ListAsync(int pageIndex, int pageSize, string term = null, long? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedResult<Order>> ListAsync(int pageIndex, int pageSize, string term = null, long? userId = null, string numeroPedido = null, string tiendaPedido = null, string estado = null, string Observacion = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Order customer)
        {
            throw new NotImplementedException();
        }
    }
}
