using CQRSData.CQRS.Queirs;
using CQRSData.Data.context;
using CQRSData.Data.Modela;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSData.CQRS.Handlers
{
    public class GetAllCategoryHandlers : IRequestHandler<GetAllCategoryQuery, List<Category>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllCategoryHandlers(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Categories.ToList());
        }
    }
}
