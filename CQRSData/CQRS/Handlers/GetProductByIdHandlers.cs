using AutoMapper;
using CQRSData.CQRS.Queirs;
using CQRSData.Data.context;
using CQRSData.Data.DTOS;
using CQRSData.Data.Modela;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSData.CQRS.Handlers
{
    public class GetProductByIdHandlers : IRequestHandler<GetProductByIdQuery, ProdShowDTO>
    {
        private readonly IMediator _mediator;
       

        public GetProductByIdHandlers(IMediator mediator)
        {

           _mediator = mediator;
           
        } 
        public async Task<ProdShowDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
         var prod= await _mediator.Send(new GetAllProductQuery());
            
            var Result =  prod.FirstOrDefault(x => x.Id == request.id);
            
            return await Task.FromResult(Result);
        }
    }
}
