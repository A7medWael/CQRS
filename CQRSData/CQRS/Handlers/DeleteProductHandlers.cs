using AutoMapper;
using CQRSData.CQRS.Commands;
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
    public class DeleteProductHandlers : IRequestHandler<DeleteProductCommands, Product>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteProductHandlers(IMediator mediator, ApplicationDbContext dbContext,IMapper mapper)
        {
            _mediator = mediator;
            _dbContext = dbContext;
            _mapper = mapper;
        }
       

        public async Task<Product> Handle(DeleteProductCommands request, CancellationToken cancellationToken)
        {
            
            var prod =  _dbContext.Products.FirstOrDefault(x => x.Id == request.id);
            _dbContext.Remove(prod);
            _dbContext.SaveChanges();
            return await Task.FromResult(prod);
        }
    }
}
