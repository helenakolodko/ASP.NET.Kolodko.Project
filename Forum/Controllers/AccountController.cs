using System.Web.Mvc;
using System.Web.Security;
using Forum.ViewModels;
using Forum.Providers;
using System.Linq;
using BLL.Interface;
using BLL.Interface.Entities;

namespace Forum.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IService<UserEntity> service;

        public AccountController(IService<UserEntity> service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            //var model = from u in service.GetAllUsers()
            //            select new UserViewModel
            //            {
            //                Email = u.Email,
            //                CreationDate = u.CreationDate,
            //                Role = u.Role.Name
            //            };
            return View(/*model*/);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong password or email.");
                }
            }
            return View(viewModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            //if (viewModel.Captcha != (string)Session[CaptchaImage.CaptchaValueKey])
            //{
            //    ModelState.AddModelError("Captcha", "Текст с картинки введен неверно");
            //    return View(viewModel);
            //}

            if (ModelState.IsValid)
            {
                MembershipUser membershipUser = ((CustomMembershipProvider)Membership.Provider)
                    .CreateUser(viewModel.Username, viewModel.Email, viewModel.Password);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Registration error.");
                }
            }
            return View(viewModel);
        }

        //В сессии создаем случайное число от 1111 до 9999.
        //Создаем в ci объект CatchaImage
        //Очищаем поток вывода
        //Задаем header для mime-типа этого http-ответа будет "image/jpeg" т.е. картинка формата jpeg.
        //Сохраняем bitmap в выходной поток с форматом ImageFormat.Jpeg
        //Освобождаем ресурсы Bitmap
        //Возвращаем null, так как основная информация уже передана в поток вывода
        //public ActionResult Captcha()
        //{
        //    Session[CaptchaImage.CaptchaValueKey] =
        //        new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString(CultureInfo.InvariantCulture);
        //    var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Helvetica");

        //    // Change the response headers to output a JPEG image.
        //    this.Response.Clear();
        //    this.Response.ContentType = "image/jpeg";

        //    // Write the image to the response stream in JPEG format.
        //    ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

        //    // Dispose of the CAPTCHA image object.
        //    ci.Dispose();
        //    return null;
        //}
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return PartialView();
        }
    }
}
