using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Common.ViewModels.User
{
    public class RoleView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserView> Users { get; set; }
        public UserView User { get; set; }
    }
}
