﻿using System;
using System.Threading.Tasks;
using Tti.Estate.Business.Dto;
using Tti.Estate.Data.Entities;

namespace Tti.Estate.Business.Services
{
    public interface IPropertyService
    {
        Task CreateAsync(Property property);
        Task<Property> GetAsync(long id);
        Task<IPagedResult<Property>> ListAsync(int pageIndex, int pageSize,
            long? userId = null,
            PropertyType? propertyType = null,
            PropertyStatus? status = null,
            TransactionType? transactionType = null,
            long? countyId = null,
            long? cityId = null,
            decimal? priceFrom = null,
            decimal? priceTo = null,
            string telephone = null,
            long? code = null
            
            );
        Task UpdateAsync(Property property);
        Task<OperationResult> DeleteAsync(long id);
        Task<OperationResult> ProcessAsync(long id, PropertyStatus status, string comment = null);
        Task<OperationResult> ActivateAsync(long id);
    }
}
