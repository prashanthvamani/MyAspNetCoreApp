using EPizzaHub.Models.Request;
using EPizzaHub.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EPizzaHub.Core.Contracts
{
    public interface IUserService
    {
       IEnumerable<UserResponseModel> GetAllUsers();

        UserResponseModel GetUserbyID(int Uid);


        bool Adduser(CreateUserRequest createUserRequest);


    }
}
