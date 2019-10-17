using System;
using Tti.Estate.Data.Entities;
namespace Tti.Estate.Data.Repositories
{
    internal class OrderRepository:BaseRepository<Order>,IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
