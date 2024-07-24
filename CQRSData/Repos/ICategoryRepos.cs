using CQRSData.Data.Modela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSData.Repos
{
    public interface ICategoryRepos
    {
        Task<IEnumerable<Category>>GetAll();
        Task<Category> GetById(int id);
        Task<int>Delete(int id);
        Task<int>Update(int id,Category category);
        Task<int>Insert(Category category);
        


    }
}
