﻿using MathEvent.Contracts;
using MathEvent.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MathEvent.Repository
{
    /// <summary>
    /// Базовый класс репозитория
    /// </summary>
    /// <typeparam name="T">Тип сущности, обрабатываемой в репозитории</typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Контекст данных для работы с базой данных
        /// </summary>
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression);
        }

        public async Task<T> CreateAsync(T entity)
        {
            var addResult = await RepositoryContext.Set<T>().AddAsync(entity);

            return addResult.Entity;
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
