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
    public class DetailViewModel : MasterPageViewModel
    {
        private readonly UserService userService;

        public DetailViewModel(UserService userService)
        {
            this.userService = userService;
        }

        public UserDetailModel User { get; set; }

        public override async Task PreRender()
        {
            int id = Convert.ToInt32(Context.Parameters["Id"]);
            User = await userService.GetUserByIdAsync(id);
            await base.PreRender();
        }
        public async Task DeleteUser()
        {
            await userService.DeleteUserAsync(User.Id);
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
        }
    }
}
