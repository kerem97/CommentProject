using CommentProject.DataAccessLayer.Abstract;
using CommentProject.EntityLayer.Concrete;
using CommentProject.Models.AppUserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly ILogger _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        public RegisterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<RegisterController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Index(RegisterViewModel rvm)
        {
            var appUser = new AppUser()
            {
                Name = rvm.Name,
                Surname = rvm.Surname,
                Email = rvm.Mail,
                UserName = rvm.Username,
                Image = "test"
            };
            if (rvm.Password == rvm.ConfirmPassword)
            {
                IdentityResult result = await _userManager.CreateAsync(appUser, rvm.Password);
                if (result.Succeeded)
                {


                    string cftoken = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

                    string link = Url.Action("ConfirmEmail", "Register", new

                    {
                        userId = appUser.Id,
                        token = cftoken
                    }, protocol: HttpContext.Request.Scheme

                        );

                    EmailConfirmation.SendEmail(link, appUser.Email);

                    //_logger.Log(LogLevel.Warning, link);

                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var x in result.Errors)
                    {
                        ModelState.AddModelError("", x.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen şifrelerinizi kontrol ediniz");
            }
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> ConfirmEmail(string userId, string token)
        //{
        //    if (userId == null || token == null)
        //    {
        //        return RedirectToAction("Index", "Title");
        //    }
        //    var user = await _userManager.FindByIdAsync(userId);

        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage($"User Id {userId} geçerli değil");
        //        return RedirectToAction("NotFound");
        //    }

        //    var result = await _userManager.ConfirmEmailAsync(user, token);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("ConfirmEmail", "Register");
        //    }
        //    ViewBag.ErrorTitle = "Mail doğrulanmadı";
        //    return RedirectToAction("Error");




        //}


        //public IActionResult NotFound()
        //{
        //    return View();
        //}

        //public IActionResult Error()
        //{
        //    return View();
        //}

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {

            var user = await _userManager.FindByIdAsync(userId);


            IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                ViewBag.status = "Tebrikler artık giriş yapabilirsiniz";
            }
            else
            {
                ViewBag.status = "Bir hata meydana geldi";
            }

            return View();


        }

    }
}
