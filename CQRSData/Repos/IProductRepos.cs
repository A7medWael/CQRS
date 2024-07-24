using CQRSData.Data.DTOS;
using CQRSData.Data.Modela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSData.Repos
{
    public interface IProductRepos
    {
        Task<IEnumerable<ProdShowDTO>> GetAll();
        Task<ProdShowDTO> GetById(int id);
        Task<int> Delete(int id);
        Task<int> Insert(ProductDTO  product);
    }
}
