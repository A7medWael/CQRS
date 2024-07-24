using AutoMapper;
using CQRSData.CQRS.Queirs;
using CQRSData.Data.context;
using CQRSData.Data.DTOS;
using CQRSData.Data.Modela;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSData.CQRS.Handlers
{
    public class GetAllProductHandlers : IRequestHandler<GetAllProductQuery, List<ProdShowDTO>>
    {
        private readonly ApplicationDbContext _context;
       private readonly IMapper _mapper;
        public GetAllProductHandlers(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProdShowDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var emp = await _context.Products.ToListAsync();
            var map = _mapper.Map<List<Product>,List<ProdShowDTO>>(emp);
            return await Task.FromResult(map);
        }

       
    }
}
