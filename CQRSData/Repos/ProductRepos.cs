using CQRSData.CQRS.Commands;
using CQRSData.CQRS.Queirs;
using CQRSData.Data.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSData.Repos
{
    public class ProductRepos : IProductRepos
    {
        private readonly IMediator _mediator;

        public ProductRepos(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<int> Delete(int id)
        {
             await _mediator.Send(new DeleteProductCommands(id));
            return 1;
        }

        public async Task<IEnumerable<ProdShowDTO>> GetAll()
        {
            return await _mediator.Send(new GetAllProductQuery());
        }

        public async Task<ProdShowDTO> GetById(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }
    

        public async Task<int> Insert(ProductDTO product)
        {
            await _mediator.Send(new InsertProductCommands(product));
            return 1;
        }

       
    }
}
