using DemoIdentityT2012EManual.Data;
using DemoIdentityT2012EManual.Models;
using DemoIdentityT2012EManual.Models.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemoIdentityT2012EManual.Controllers
{
    public class AccountsController : Controller
    {
        private MyIdentityDbContext db;
        private UserManager<Account> userManager;                     
        private RoleManager<IdentityRole> roleManager;                     

        public AccountsController()
        {
            db = new MyIdentityDbContext();            
            UserStore<Account> userStore = new UserStore<Account>(db);
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(db);
            userManager = new UserManager<Account>(userStore);
            roleManager = new RoleManager<IdentityRole>(roleStore);        
        }

        [Authorize(Roles = "User")]
        public ActionResult UserPage() {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminPage()
        {
            return View();
        }

        [Authorize(Roles = "Employee")]
        public ActionResult EmployeePage()
        {
            return View();
        }

        // GET: Accounts
        public ActionResult Index()
        {
            ViewData["userManager"] = userManager;
            ViewData["roles"] = roleManager.Roles.ToList();
            var list = userManager.Users.ToList();
            return View(list);
        }

        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountRegisterViewModel accountViewModel)
        {           
            Account account = new Account()
            {
                UserName = accountViewModel.UserName,
                Email = accountViewModel.Email,
                PhoneNumber = accountViewModel.Phone,
                IdentityNumber = accountViewModel.IdentityNumber,
                Status = accountViewModel.Status
            };            
            var result = await userManager.CreateAsync(account, accountViewModel.Password);
            if (result.Succeeded)
            {
                return View("CreateAccountSuccess");
            }
            else
            {
                return View("CreateAccountFails");
            }            
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            // sử dụng userManager để check thông tin đăng nhập.
            var account = await userManager.FindAsync(loginViewModel.Username, loginViewModel.Password);
            if (account != null)
            {
                // đăng nhập  thành công thì dùng SignInManager để lưu lại thông tin vừa đăng nhập.
                var signInManager = new SignInManager<Account, string>(userManager, Request.GetOwinContext().Authentication);
                await signInManager.SignInAsync(account, isPersistent: false, rememberBrowser: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("CreateAccountFails");
            }            
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Accounts/Login");
        }

        public ActionResult ChangeStatus(string ids, string statusToChange) {
            var arrayId = ids.Split(new[]{ ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            var accounts = db.Users.Where(f => arrayId.Contains(f.Id)).ToList();
            accounts.ForEach(a => a.Status = Int32.Parse(statusToChange));
            db.SaveChanges();
            ViewData["userManager"] = userManager;
            ViewData["roles"] = roleManager.Roles.ToList();
            var list = userManager.Users.ToList();
            return PartialView("ListAccount", list);
        }

        public ActionResult ChangeRole(string roleIds, string roleToChange)
        {
            var arrayId = roleIds.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            IdentityRole role =  db.Roles.Find(roleToChange);
            if (role == null) {
                return View("CreateAccountFails");
            }
            var accounts = db.Users.Where(f => arrayId.Contains(f.Id)).ToList();
            foreach (var acc in accounts) {
                if(userManager.IsInRole(acc.Id, roleToChange)){
                    continue;
                }
                userManager.AddToRole(acc.Id, role.Name);                
            }            
            ViewData["userManager"] = userManager;
            ViewData["roles"] = roleManager.Roles.ToList();
            var list = userManager.Users.ToList();
            return PartialView("ListAccount", list);
        }
    }
}