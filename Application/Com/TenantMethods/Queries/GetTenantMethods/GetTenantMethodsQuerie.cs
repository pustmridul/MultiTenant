﻿using Application.Com.PaymentMethods.Models;
using Application.Com.PaymentMethods.Queries.GetAllPaymentMethod;
using Application.Com.TenantMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.TenantMethods.Queries.GetTenantMethods;

public record GetTenantMethodsQuerie : IRequest<PaginatedList<TenantDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTenantMethodsQuerieHandler : IRequestHandler<GetTenantMethodsQuerie, PaginatedList<TenantDto>>
{
   
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetTenantMethodsQuerieHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TenantDto>> Handle(GetTenantMethodsQuerie request, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Tenants
           .OrderBy(x => x.TenantName)
           .ProjectTo<TenantDto>(_mapper.ConfigurationProvider)
           .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}
