using CQRSData.CQRS.Commands;
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
    public class DeleteCategoryHandlers : IRequestHandler<DeleteCategoryCommands, Category>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _dbContext;

        public DeleteCategoryHandlers(IMediator mediator, ApplicationDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }
        public async Task<Category> Handle(DeleteCategoryCommands request, CancellationToken cancellationToken)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(request.id));
             _dbContext.Remove(category);
            _dbContext.SaveChanges();
            return await Task.FromResult(category);
        }
    }
}
