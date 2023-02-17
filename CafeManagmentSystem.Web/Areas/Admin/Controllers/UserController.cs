using CafeManagementSystem.Common.AttributesErrorMessageCommon;
using CafeManagementSystem.Commons;
using CafeManagementSystem.DataLayer;
using CafeManagementSystem.ViewModel.Users;
using CafeSystemManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagementSystem.Areas.Admin.Controllers
{
    [Area(AreaAttributs.AreaAdmin)]
    public class UserController : Controller
    {
        private readonly DataContext _db;

        public UserController(DataContext dataContext)
        {
            _db = dataContext;
        }
        public IActionResult Index()
        {
            var users = _db.UserInfos.ToList();
            return View(users);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new UserInfo()
                {
                    UserName = model.UserName,
                    UserNumber = model.phoneNumber,
                    UserPassword = model.password,
                    AddedDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                _db.UserInfos.Add(newUser);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, ErrorMessageCommon.ModelStateErrorMessage);
                return View(model);
            }
        }

        public IActionResult UpdateUser(int id)
        {
            var targetUser = _db.UserInfos.Find(int.Parse(id.ToString()));

            var model = new UpdateUserViewModel()
            {
                userId = targetUser.UserId,
                UserName = targetUser.UserName,
                phoneNumber = targetUser.UserNumber,
                password = targetUser.UserPassword
            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult UpdateUser(UpdateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var targetUser = _db.UserInfos.Find(int.Parse(model.userId.ToString()));
                var currentUserPass = targetUser.UserPassword;
                
                targetUser.UserName = model.UserName;
                targetUser.UserNumber = model.phoneNumber;
                targetUser.UpdateDate = DateTime.Now;

                if (model.password is null)
                {
                    targetUser.UserPassword = currentUserPass;
                }
                else
                    targetUser.UserPassword = model.password;

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, ErrorMessageCommon.ModelStateErrorMessage);
                return View(model);
            }
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int id)
        {
            var targetUser = _db.UserInfos.Find(int.Parse(id.ToString()));

            _db.Remove(targetUser);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
