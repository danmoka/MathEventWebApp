﻿using MathEvent.Contracts;
using MathEvent.Entities;
using System.Threading.Tasks;

namespace MathEvent.Repository
{
    /// <summary>
    /// Оболочка для репозиториев. Позволяет не добавлять в DI все классы репозиториев
    /// </summary>
    public class RepositoryWrapper : IRepositoryWrapper
    {
        /// <summary>
        /// Контекст данных для работы с базой данных
        /// </summary>
        private RepositoryContext _repositoryContext;

        /// <summary>
        /// Репозиторий для работы с Событиями
        /// </summary>
        private IEventRepository _event;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        /// <summary>
        /// Предоставляет репозиторий для работы с Событиями
        /// </summary>
        public IEventRepository Event
        {
            get
            {
                if (_event is null)
                {
                    _event = new EventRepository(_repositoryContext);
                }

                return _event;
            }
        }

        /// <summary>
        /// Фиксирует изменения, совершенные репозиториями над контекстом данных
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}