using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models.ViewModels
{
    public class ChangeRoleViewModel
    {
        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }

        public string UserId { set; get; }

        public string UserName { set; get; }

        public List<IdentityRole> AllRoles { set; get; }
        public IList<string> UserRoles { set; get; }



    }
}
