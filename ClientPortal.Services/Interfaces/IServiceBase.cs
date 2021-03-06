﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClientPortal.Services
{
    public interface IServiceBase<TModel> where TModel : class
    {
        Task<TModel> AddAsync(TModel model);
        Task DeleteAsync(TModel model);
        Task DeleteAsync(object id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(object id);
        Task<TModel> updateAsync(TModel model, object id);
    }
}
