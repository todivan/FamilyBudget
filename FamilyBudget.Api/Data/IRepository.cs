﻿using FamilyBudget.Api.Model;
using System.Security.Principal;

namespace FamilyBudget.Data
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll(int pageNumber, int pageSize);
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
