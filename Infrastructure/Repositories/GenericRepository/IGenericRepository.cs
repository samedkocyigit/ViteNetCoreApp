﻿namespace ViteNetCoreApp.Infrastructure.Repositories.GenericRepository
{
    public interface IGenericRepository
    {
        public interface IGenericRepository<T> where T : class
        {
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task<T> AddAsync(T entity);
            Task<T> UpdateAsync(T entity);
            Task DeleteAsync(int id);
        }

    }
}
