using Charity.Context;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Services
{
    public class UserManagerService : IUserManagerService
    {
        #region Dependency Injection
        private readonly CharityContext context;
        public UserManagerService(CharityContext context)
        {
            this.context = context;
        }
        #endregion
        // Returns true if there is only one user with name "Administrator"

        public bool IsEmailUnique(string email)
        {
            return context.Users.Where(u => u.NormalizedEmail == email.ToUpper()).FirstOrDefault() == null;
        }

        public IdentityUser GetUserByEmail(string email)
        {
            return context.Users.Where(u => u.NormalizedEmail == email.ToUpper()).FirstOrDefault();
        }
    }
}
