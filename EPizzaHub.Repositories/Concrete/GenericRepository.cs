using EPizzaHub.Domain.Models;
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

        public IEnumerable<T> GetAll()
        {
           return _dbContext.Set<T>().ToList();
        }
    }
}
