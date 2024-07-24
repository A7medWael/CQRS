using AutoMapper;
using CQRSData.Data.DTOS;
using CQRSData.Data.Modela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSData.Data.Mapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Product,ProdShowDTO>().ReverseMap();
        }
    }
}
