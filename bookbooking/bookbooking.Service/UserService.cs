using bookbooking.Common.ViewModels;
using bookbooking.Data;
using bookbooking.Entity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookbooking.Service
{
    public class UserService
    {
        private readonly IRepository<User> repository;
        public UserService(IRepository<User> _repository)
        {
            repository = _repository;
        }
        public ICollection<UserListView> ListUser ()
        {
            List<UserListView> userListView = new List<UserListView>();
            foreach (var item in repository.GetAll())
            {
                userListView.Add(
                    new UserListView() { Username=item.Username, Password=item.Password}
                    );
            }
            return userListView;
        }
        public void AddUser(User user)
        {
            repository.Add(user);
        }
        public void UpdateUser(User user)
        {
            repository.Add(user);
        }

        public void RemoveUser(User user)
        {
            repository.Add(user);
        }

    }
}
