using CQRSData.Data.Modela;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSData.CQRS.Commands
{
    public record UpdateCategoryCommands(int id,Category category):IRequest<Category>;
    
}
