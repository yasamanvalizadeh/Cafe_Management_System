
using CafeManagementSystem.Common.AttributesErrorMessageCommon;
using CafeManagementSystem.DataLayer;
using CafeManagementSystem.ViewModel.Accounts;
using CafeSystemManagement.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Diagnostics;

namespace CafeManagementSystem.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly DataContext _db;

        public HomeController(ILogger<HomeController> logger , DataContext dataContext )
		{
			_logger = logger;
			_db = dataContext;
		}

		public IActionResult Index()
		{ 
            return View();
		}

		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult SignUp(SignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
                var newUser = new UserInfo()
                {
                    UserName = model.UserName,
                    UserNumber = model.phoneNumber,
                    UserPassword = model.password,
                    AddedDate = DateTime.Now
                };

				_db.UserInfos.Add(newUser);
                _db.SaveChanges(); 
                return Json("succuss");
            }
			else
			{
				return BadRequest();
			} 
		}
		 
        public IActionResult LogOut() 
		{
			return View();
		}

	}
}