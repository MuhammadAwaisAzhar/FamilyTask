using AutoMapper;
using ClientPortal.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClientPortal.Services
{
    public abstract class ServiceBase<TModel, TEntity> : IServiceBase<TModel>
       where TModel : class
       where TEntity : class
    {
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<TEntity> _genericRepository;
        public ServiceBase(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public virtual async Task<TModel> AddAsync(TModel model)
        {
            var result = await _genericRepository.AddAsync(_mapper.Map<TEntity>(model));
            return _mapper.Map<TModel>(result);
        }

        public virtual async Task DeleteAsync(TModel model)
        {
            await _genericRepository.DeleteAsync(_mapper.Map<TModel>(model));
        }

        public virtual async Task DeleteAsync(object id)
        {
            await _genericRepository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var result = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TModel>>(result);
        }

        public virtual async Task<TModel> GetByIdAsync(object id)
        {
            var result = await _genericRepository.GetByIdAsync(id);
            return _mapper.Map<TModel>(result);
        }
        public virtual async Task<TModel> updateAsync(TModel model, object id)
        {
            var result = await _genericRepository.UpdateAsyc(id, _mapper.Map<TEntity>(model));
            return _mapper.Map<TModel>(result);
        }
    }
}
