using EPizzaHub.Domain.Models;
using EPizzaHub.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Core.Contracts
{
    public interface IAuthService
    {
        ValidateuserResponse CheckUser(string Uname,string Pwd);

    }
}
