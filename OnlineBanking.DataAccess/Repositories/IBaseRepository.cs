using OnlineBanking.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.DataAccess
{
    public interface IBaseRepository<TEntity, TDto>
    {
        int? Add(TDto model);
        bool Update(TDto model);
        List<TDto> GetAll();
        TDto GetById(int id);
        void SaveChanges();
    }
}
