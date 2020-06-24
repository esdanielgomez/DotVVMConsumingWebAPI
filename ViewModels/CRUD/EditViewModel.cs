using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Runtime.Filters;
using DotVVM_APIConsume.Models;
using DotVVM_APIConsume.Services;

namespace DotVVM_APIConsume.ViewModels.CRUD
{
    public class EditViewModel : MasterPageViewModel
    {
        private readonly UserService userService;
        public UserDetailModel User { get; set; }

        public EditViewModel(UserService userService)
        {
            this.userService = userService;
        }


        public override async Task PreRender()
        {
			int id = 0;
            if (int.TryParse(Context.Parameters["Id"].ToString(), out id))
            {
                User = await userService.GetUserByIdAsync(id);
            }
            await base.PreRender();
        }


        public async Task EditUser()
        {
            await userService.UpdateUserAsync(User);
            Context.RedirectToRoute("CRUD_Detail", new {id = User.Id});
        }
    }
}
