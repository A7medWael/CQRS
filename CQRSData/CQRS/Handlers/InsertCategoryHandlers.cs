using CQRSData.CQRS.Commands;
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
    public class InsertCategoryHandlers : IRequestHandler<InsertCategoryCommands, Category>
    {
        private readonly ApplicationDbContext _context;
        public InsertCategoryHandlers(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Handle(InsertCategoryCommands request, CancellationToken cancellationToken)
        {
            await _context.AddAsync(request.Category);
           await _context.SaveChangesAsync();
            return await Task.FromResult(request.Category);
        }
    }
}
