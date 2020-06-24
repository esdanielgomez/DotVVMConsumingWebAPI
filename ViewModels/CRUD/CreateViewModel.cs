using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Runtime.Filters;
using DotVVM_APIConsume.Models;
using DotVVM_APIConsume.Services;

namespace DotVVM_APIConsume.ViewModels.CRUD
{
    public class CreateViewModel : MasterPageViewModel
    {
        private readonly UserService userService;
        public UserDetailModel User { get; set; } = new UserDetailModel { EnrollmentDate = DateTime.UtcNow.Date };

        public CreateViewModel(UserService userService)
        {
            this.userService = userService;
        }

        public async Task AddUser()
        {
            await userService.InsertUserAsync(User);
            Context.RedirectToRoute("Default");
        }
    }
}
