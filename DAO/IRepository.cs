﻿namespace ProjetStage.DAO
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(int id);
        Task Delete(int id);
    }
}