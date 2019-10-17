using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;
using Tti.Estate.Business.Exceptions;
using Tti.Estate.Business.Specifications;
using Tti.Estate.Data.Entities;
using Tti.Estate.Data.Repositories;


namespace Tti.Estate.Business.Validators
{
    public class OrderValidator:IOrderValidator
    {
        public OrderValidator()
        {
        }
    public Task ValidateAsync(Order entity, OrderAction action)
        {
            throw new NotImplementedException();
        }
    }
}
