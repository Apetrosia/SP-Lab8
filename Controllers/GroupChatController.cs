using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GreenSwampApp.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace GreenSwampApp.Controllers
{
    [Authorize]
    public class GroupChatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupChatController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Register", "Account");
            }

            var user = _context.Users.FirstOrDefault(u => u.UserId.ToString() == userId);
            if (user == null)
            {
                return RedirectToAction("Register", "Account");
            }

            ViewBag.Username = user.Username;
            ViewBag.ProfilePictureUrl = user.AvatarUrl ?? "/images/green-toad-sad.svg";

            return View();
        }
    }
}