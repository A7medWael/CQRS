using CQRSData.CQRS.Commands;
using CQRSData.CQRS.Queirs;
using CQRSData.Data.Modela;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSData.Repos
{
    public class CategoryRepos : ICategoryRepos
    {
        private readonly IMediator _mediator;

        public CategoryRepos(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<int> Delete(int id)
        {
            await _mediator.Send(new DeleteCategoryCommands(id));
            return 1;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _mediator.Send(new GetAllCategoryQuery());
        }

        public async Task<Category> GetById(int id)
        {
            return await _mediator.Send(new GetCategoryByIdQuery(id));
        }

        public async Task<int> Insert(Category category)
        {
            await _mediator.Send(new InsertCategoryCommands(category));
            return 1;
        }

        public async Task<int> Update(int id, Category category)
        {
            await _mediator.Send(new UpdateCategoryCommands(id,category));
            return 1;
        }
    }
}
