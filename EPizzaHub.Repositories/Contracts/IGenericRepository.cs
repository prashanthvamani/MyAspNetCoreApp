using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);

        IEnumerable<T> GetAll();


        int CommitChanges();
    }
}
