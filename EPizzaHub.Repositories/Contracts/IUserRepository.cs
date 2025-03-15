using EPizzaHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Repositories.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User checkuser(string emailID);
    }
}
