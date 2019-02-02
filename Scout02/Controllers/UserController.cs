using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Project.Entity;
using Scout02.Entity;
using Scout02.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Scout02.Controllers
{
    public class UserController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;


        public UserController()
        {

        }
        public UserController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        private IQueryable<AllUserViewModel> GetUserInformations(string userId)
        {
            if (userId == "")
            {
                var role = db.Roles.SingleOrDefault(m => m.Name != "Admin");
                var user = UserManager.Users.Where(m => m.Roles.All(r => r.RoleId == role.Id)).Select(b => new AllUserViewModel()
                {
                    ImagePath = b.UserImages.Pictures.Select(i => i.ImagePath).FirstOrDefault(),
                    ApplicationUserId = b.Id,
                    Birthday = b.Birthday,
                    Email = b.Email,
                    IsActive = b.EmailConfirmed,
                    Gender = b.Gender,
                    Name = b.Name,
                    RegisterDate = b.RegisterDate,
                    Surname = b.Surname
                });
                return user;
            }
            else
            {
                var user = db.UserContact.Where(i => i.Id == userId).Select(i => new AllUserViewModel()
                {
                    UserId = i.Id,
                    ImagePath = i.ApplicationUser.UserImages.Pictures.Select(b => b.ImagePath).FirstOrDefault(),
                    Birthday = i.ApplicationUser.Birthday,
                    Gender = i.ApplicationUser.Gender,
                    IsActive = i.ApplicationUser.EmailConfirmed,
                    Name = i.ApplicationUser.Name,
                    UserName = i.ApplicationUser.UserName,
                    RegisterDate = i.ApplicationUser.RegisterDate,
                    Surname = i.ApplicationUser.Surname,
                    Email = i.ApplicationUser.Email,
                    UserContactId = i.UserAddresses.Select(a => a.UserContactId).FirstOrDefault(),
                    AddressId = i.UserAddresses.Select(a => a.Id).FirstOrDefault(),
                    City = i.UserAddresses.Select(a => a.City).FirstOrDefault(),
                    UserAddress = i.UserAddresses.Select(a => a.UserAddress).FirstOrDefault(),
                    UserSocialAccounts = i.UserSocialAccounts.FirstOrDefault(),

                });
                return user;
            }
        }
        private ActionResult MailConfirm(string userName)
        {
            string result = "";
            var user = db.UserContact.Where(i => i.ApplicationUser.Id == userName).FirstOrDefault();
            user.ApplicationUser.EmailConfirmed = true;
            db.SaveChanges();
            if (user != null)
            {
                result = "olumlu";
            }
            else
            {
                result = "olumsuz";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SearchResult(string searchText)
        {

            var list = db.Users.Where(b => b.Name.Contains(searchText) || b.UserName.Contains(searchText) || b.Surname.Contains(searchText) || b.UserName.Contains(searchText)).
                         Select(b => new AllUserViewModel()
                         {
                             ImagePath = b.UserImages.Pictures.Select(i => i.ImagePath).FirstOrDefault(),
                             ApplicationUserId = b.Id,
                             Birthday = b.Birthday,
                             Email = b.Email,
                             IsActive = b.EmailConfirmed,
                             Gender = b.Gender,
                             Name = b.Name,
                             RegisterDate = b.RegisterDate,
                             Surname = b.Surname
                         })
                        .ToList();


            return PartialView("~/Views/Shared/Partials/SearchPartial.cshtml", list);


        }
        //
        // GET: User
        //[Authorize(Roles ="Admin")]
        public ActionResult Index(int? page)
        {
            var user = GetUserInformations("").ToList().ToPagedList(page ?? 1,3);
            return View(user);
        }
        //
        // GET: User
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roleId = db.Users.Where(a=>a.Id==id).FirstOrDefault();
            var rolex = roleId.Roles.Select(a => a.RoleId).FirstOrDefault();
            var RoleName = RoleManager.Roles.Where(a=>a.Id==rolex.ToString()).Select(a=>a.Name).FirstOrDefault();
            ViewBag.Rolex = RoleName;
            var user = GetUserInformations(id).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.UserContact, "Id", "Id", user.UserId);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(UserDetail user)
        public ActionResult Edit([Bind(Include = "UserId,UserContactId,AddressId,Name,Surname,Birthday,Gender,Email,IsActive,UserName,UserAddress,City,UserSocialAccounts")] UserDetail user)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    var users = (ApplicationUser)UserManager.FindById(user.UserId);
                    UserAddresses address = new UserAddresses();
                    users.Id = user.UserId;
                    users.Birthday = user.Birthday;
                    users.Name = user.Name;
                    users.Surname = user.Surname;
                    users.Email = user.Email;
                    users.Gender = user.Gender;
                    users.EmailConfirmed = user.IsActive;
                    users.Gender = user.Gender;
                    users.UserName = user.UserName;
                    users.EmailConfirmed = user.IsActive;
                    //db.Entry(users).State = EntityState.Modified;
                    UserManager.Update(users);
                    address.Id = user.AddressId;
                    
                    address.UserContactId = user.UserContactId;
                    address.UserAddress = user.UserAddress;
                    address.City = user.City;
                    UserSocialAccounts social = user.UserSocialAccounts;

                    db.Entry(address).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Response.Write(string.Format("Entity türü \"{0}\" şu hatalara sahip \"{1}\" Geçerlilik hataları:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Response.Write(string.Format("- Özellik: \"{0}\", Hata: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                        }
                        Response.End();
                    }

                }

                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.UserContact, "Id", "Id", user.UserId);
            return View(user);
        }
        //GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = GetUserInformations(id).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

    }
}