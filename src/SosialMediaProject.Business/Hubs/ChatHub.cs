using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SosialMediaProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserManager<AppUser> _userManager;     

        public ChatHub(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
        public async Task SendMessage(string toUserId, string message)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var fromUser = await _userManager.FindByNameAsync(Context.User.Identity.Name);

                if (fromUser != null)
                {
                    AppUser user = _userManager.FindByIdAsync(toUserId).Result;
					if (user != null)
					{
						if (user.ConnectionId != null && fromUser.ConnectionId != null)
						{
							await Clients.Client(user.ConnectionId).SendAsync("recievePrivateMessage", fromUser.Id, fromUser.FullName, message);
							await Clients.Client(fromUser.ConnectionId).SendAsync("sendPrivMessage", user.Id, user.FullName, message);
						}
					}				
                   
                }
            }
               
        }
	

		public override async Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(Context.User.Identity.Name);
                if (user != null)
                {
                    user.ConnectionId = Context.ConnectionId;
                    await _userManager.UpdateAsync(user);
                    await Clients.All.SendAsync("OnConnect", user.Id);
                }
            }
        }


        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(Context.User.Identity.Name);
                if (user != null)
                {
                    user.ConnectionId = null;
                    await _userManager.UpdateAsync(user);
                    await Clients.All.SendAsync("DisConnect", user.Id);
                }
            }
        }




    }
}
