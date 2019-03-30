using bookbooking.Common.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Common.ViewModels.Role
{
    public class UserRoleView
    {
        public List<UserView> Member { get; set; }
        public List<UserView> NoMember { get; set; }
        public string[] IdsToDelete { get; set; }
        public string[] IdsToAdd { get; set; }
        public IdentityRole IdentityRole { get; set; }
        public IEnumerable<IdentityRole> ıdentityRoles { get; set; }
    }
}
