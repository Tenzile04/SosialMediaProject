using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SosialMediaProject.Business.Hubs;
using SosialMediaProject.Core.Models;

namespace SosialMediaProject.MVC.Controllers
{
    public class ChatController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHubContext<ChatHub> _hubContext;
        public ChatController(UserManager<AppUser> userManager,IHubContext<ChatHub> hubContext)
        {
            _userManager = userManager;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> PrivateChat(string userId, string message)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            await _hubContext.Clients.Client(user.ConnectionId).SendAsync("SendMessagePrivate", message);

            return RedirectToAction(nameof(Index));
        }
    } 

}
