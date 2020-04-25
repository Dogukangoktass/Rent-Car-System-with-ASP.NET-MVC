using RCP.BL;
using RCP.Model;
using RCP.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCP.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        // GET: Profile
        public ActionResult Profile()
        {
            return View();
        }
        // Post : Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UserRepository repo = new UserRepository();
            var user = repo.Login(model.Email,model.Password,model.Username);
            if (user != null)
            {
                //
                Session["LoginUser"] = user;
                return RedirectToAction("Profile");
            }
            else
            {
                TempData["Mesaj"] = new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kullanıcı Adı veya şifre hatalı!" } };
                return View();
            }
        }
        // Post : Register
        [HttpPost]
        public ActionResult Register(User model)
        {
            UserRepository repo = new UserRepository();
            RoleRepository rolRepo = new RoleRepository();
            bool result = repo.Add(new Model.User { Name = model.Name, Password = model.Password, Surname = model.Surname, Email = model.Email, IsDelete = false, RegisterDate = DateTime.Now, Username=model.Username });
            var userId = repo.GetByFilter(x => x.Email == model.Email).FirstOrDefault().Id;
            var roleId = rolRepo.GetByFilter(x => x.RoleName == "Admin").FirstOrDefault().Id;
            repo.AddRole(userId, roleId);
            TempData["Mesaj"] = result ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Kayıt eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kayıt eklenemedi." } };
            return View();
        }
    }
}