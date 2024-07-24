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
    public class GetCategoryByIdHandlers : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly IMediator _mediator;
        

        public GetCategoryByIdHandlers(IMediator mediator)
        {
           _mediator = mediator;
            
        }
        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
           var categories=await _mediator.Send(new GetAllCategoryQuery());
            var Result = categories.FirstOrDefault(x => x.Id == request.id);
            return await Task.FromResult(Result);
        }
    }
}
