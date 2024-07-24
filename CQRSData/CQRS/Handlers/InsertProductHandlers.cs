using AutoMapper;
using CQRSData.CQRS.Commands;
using CQRSData.Data.context;
using CQRSData.Data.DTOS;
using CQRSData.Data.Modela;
using CQRSData.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSData.CQRS.Handlers
{
    public class InsertProductHandlers : IRequestHandler<InsertProductCommands, ProductDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
       
        public InsertProductHandlers(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        

        public async Task<ProductDTO> Handle(InsertProductCommands request, CancellationToken cancellationToken)
        {
           
            var map = _mapper.Map<Product>(request.productDTO);
            map.ImageUrl = DocumentSettings.UploadFile(request.productDTO.Photo, "Images");
            await _context.AddAsync(map);
            await _context.SaveChangesAsync();
            return await Task.FromResult(request.productDTO);
        }
    }
}
