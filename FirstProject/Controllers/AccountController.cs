using System.Security.Claims;
using FirstProject.Data.Repositories;
using FirstProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region Register

        public IActionResult Rigester()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rigester(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userRepository.IsExistEmail(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email","ایمیل وارد شده تکراری است ");
                return View(register);
            }

            Users users = new Users()
            {
                Email = register.Email.ToLower(),
                DateTime = DateTime.Now,
                IsAdmin = false,
                Password = register.Password
            };
            _userRepository.AddUser(users);
            return RedirectToAction("Login");
        }

        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            // aghar dar ghesmat validation moshkel dashe bashe inja Err mideh
            if (!ModelState.IsValid)        
            {
                return View(login);
            }

           
            var User = _userRepository.user(login.Email,login.Password);
            if (User==null)
            {
                ModelState.AddModelError("Email","ایمیل و رمز وارد شده مطابقت ندارد .");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()),
                new Claim(ClaimTypes.Name, User.Email),
               // new Claim("CodeMeli", user.Email),

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }

        #endregion

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
