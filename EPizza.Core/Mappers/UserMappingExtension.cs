using EPizzaHub.Domain.Models;
using EPizzaHub.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Core.Mappers
{
    public static class UserMappingExtension
    {
        public static IEnumerable<UserResponseModel> ConverttoUserResponseModel(
            this IEnumerable<User> Ulist)
        {
            List<UserResponseModel> responseModelslist = new List<UserResponseModel>();

            if(Ulist.Any())
            {
                foreach (var user in Ulist)
                {
                    UserResponseModel UresponseModel = new UserResponseModel()
                    {
                        UserId = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Password = user.Password,
                        PhoneNumber = user.PhoneNumber,
                        CreatedDate = user.CreatedDate,
                    };

                    responseModelslist.Add(UresponseModel);
                }
            }
            return responseModelslist;
        }

        public static IEnumerable<UserResponseModel> ConvertUserResponseModelUsingLinq(
            this IEnumerable<User> Ulist)
        {
            return Ulist.Select(x => x.ConvertUserResponseModelUsingLinq());
        }

        public static UserResponseModel ConvertUserResponseModelUsingLinq(
            this User user)
        {
            return new UserResponseModel
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                CreatedDate = user.CreatedDate
            };
        }
    }
}
