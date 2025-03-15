using AutoMapper;
using EPizzaHub.Core.Contracts;
using EPizzaHub.Core.Mappers;
using EPizzaHub.Domain.Models;
using EPizzaHub.Models.Request;
using EPizzaHub.Models.Response;
using EPizzaHub.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Core.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public bool Adduser(CreateUserRequest UserRequest)
        {
            var roles = _roleRepository.GetAll().Where(x => x.Name == "User").FirstOrDefault();

            if (roles != null)
            {

                var userdetails = _mapper.Map<User>(UserRequest);

                userdetails.Roles.Add(roles);

                userdetails.Password = BCrypt.Net.BCrypt.HashPassword(userdetails.Password);

                _userRepository.Add(userdetails);

                int effect = _userRepository.CommitChanges();

                return effect > 0;

                //throw new NotImplementedException();
            }
            return false;

        }

        public IEnumerable<UserResponseModel> GetAllUsers()
        {
            var users = _userRepository.GetAll().AsEnumerable();

            var userResponse = _mapper.Map<IEnumerable<UserResponseModel>>(users);

            return userResponse;

            //return users.ConvertUserResponseModelUsingLinq();
        }

        public UserResponseModel GetUserbyID(int Uid)
        {
            var users = _userRepository.GetAll().AsEnumerable().FirstOrDefault();
            return users.ConvertUserResponseModelUsingLinq();
        }
    }
}
