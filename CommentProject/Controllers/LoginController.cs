using CommentProject.EntityLayer.Concrete;
using CommentProject.Models.AppUserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CommentProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel lgn)
        {
            var result = await _signInManager.PasswordSignInAsync(lgn.Username, lgn.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Title");
            }
            else
            {
                ModelState.AddModelError(" ", "Lütfen mail adresinizi onaylayınız");
                return View();
            }

        }
    }
}
