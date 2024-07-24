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
    public class UpdateCategoryHandlers : IRequestHandler<UpdateCategoryCommands, Category>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _dbContext;

        public UpdateCategoryHandlers(IMediator mediator, ApplicationDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }
        public async Task<Category> Handle(UpdateCategoryCommands request, CancellationToken cancellationToken)
        {
            var categorie = await _mediator.Send(new GetCategoryByIdQuery(request.id));
            categorie.Name = request.category.Name;
            categorie.Status = request.category.Status;
             _dbContext.Update(categorie);
            _dbContext.SaveChanges();
            return await Task.FromResult(categorie);
            
        }
    }
}
