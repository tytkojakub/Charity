using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Services.Interfaces
{
    public interface IUserManagerService
    {
        public IdentityUser GetUserByEmail(string email);
        public bool IsEmailUnique(string email);
    }
}