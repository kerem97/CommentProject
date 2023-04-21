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
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel lgn)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(lgn.Email);

            var result = await _signInManager.PasswordSignInAsync(lgn.Username, lgn.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Title");
            }
            //else
            //{
            //    ModelState.AddModelError(" ", "Lütfen mail adresinizi onaylayınız");
            //    return View();
            //}

            if (_userManager.IsEmailConfirmedAsync(appUser).Result == false)
            {
                ModelState.AddModelError("", "Email adresiniz doğrulanmamıştır lütfen mail adresinizi onaylayıp tekrar deneyiniz");
                return View(lgn);
            }
            return View();


        }
    }
}
