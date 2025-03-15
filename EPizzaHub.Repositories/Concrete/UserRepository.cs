using EPizzaHub.Domain.Models;
using EPizzaHub.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Repositories.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository 
    {
        public UserRepository(ePizzaHubDBContext dBContext) : base(dBContext) 
        {
            
        }

        public User checkuser(string emailID)
        {
            return _dbContext.Users.Where(x => x.Email == emailID).FirstOrDefault()!    ;

            //throw new NotImplementedException();
        }
    }
}
