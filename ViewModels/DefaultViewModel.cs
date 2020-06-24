using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM_APIConsume.Models;
using DotVVM_APIConsume.Services;

namespace DotVVM_APIConsume.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly UserService userService;

		public DefaultViewModel(UserService userService)
        {
            this.userService = userService;
        }

        [Bind(Direction.ServerToClient)]
        public List<UserListModel> Users { get; set; }

        public override async Task PreRender()
        {
            Users = await userService.GetAllUsersAsync();
            await base.PreRender();
        }
    }
}