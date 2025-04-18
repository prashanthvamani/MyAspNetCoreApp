﻿using EPizzaHub.Domain.Models;
using EPizzaHub.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected ePizzaHubDBContext _dbContext;

        public GenericRepository(ePizzaHubDBContext dbContext)
        {
            _dbContext = dbContext;
        }



        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public int CommitChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Delete(object id)
        {
            T entity = _dbContext.Set<T>().Find(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
           return _dbContext.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
