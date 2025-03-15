using AutoMapper;
using EPizzaHub.Core.Contracts;
using EPizzaHub.Models.Response;
using EPizzaHub.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Core.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        //private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AuthService(IUserRepository userRepository ,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ValidateuserResponse CheckUser(string Uname,string pwd)
        {
            var checkuser = _userRepository.checkuser(Uname);

            if(checkuser != null)
            {
                bool isvalid = BCrypt.Net.BCrypt.Verify(pwd, checkuser.Password);

                if (isvalid)
                {
                    return new ValidateuserResponse
                    {
                        Email = Uname,
                        Name = checkuser.Name,
                        Roles = checkuser.Roles.Select(x => x.Name).ToList()
                    };
                }
                else
                {
                    throw new Exception($"Incorrect credentials passed for the User {Uname}");
                }
            }

            throw new Exception($"The user with the email address {Uname} doesn't exists.");


        }
    }
}
