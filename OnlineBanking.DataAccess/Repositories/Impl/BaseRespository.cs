using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.DataAccess
{
    public class BaseRepository<TEntity, TDto> : IBaseRepository<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public BaseRepository(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public virtual int? Add(TDto model)
        {
            int? result = null;

            try
            {
                var entity = _mapper.Map<TEntity>(model);

                entity.CreatedDate = DateTime.Now;

                _databaseContext.Set<TEntity>().Add(entity);

                _databaseContext.EnsureAutoHistory(() => new CustomAutoHistory()
                {
                    Kind = EntityState.Modified
                });

                SaveChanges();

                result = entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public virtual bool Update(TDto model)
        {
            var result = false;

            try
            {
                var entity = _databaseContext.Set<TEntity>().Find(model.Id);

                _databaseContext.Entry(entity).CurrentValues.SetValues(model);

                entity.ModifiedDate = DateTime.Now;

                _databaseContext.EnsureAutoHistory(() => new CustomAutoHistory()
                {
                    Kind = EntityState.Modified
                });

                SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public List<TDto> GetAll()
        {
            var result = new List<TDto>();

            List<TEntity> list;

            try
            {
                list = _databaseContext.Set<TEntity>().ToList();

                result = _mapper.Map<List<TDto>>(list);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public virtual TDto GetById(int id)
        {
            try
            {
                return _mapper.Map<TDto>(_databaseContext.Set<TEntity>().Find(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }
    }
}
