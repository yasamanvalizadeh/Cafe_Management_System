using CafeManagementSystem.Common.AttributesErrorMessageCommon;
using CafeManagementSystem.DataLayer;
using CafeManagementSystem.ViewModel.Orders;
using CafeSystemManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _db;
        public UserController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MakeOrder()
        {
            var model = new MakeOrderViewModel();
            var items = new List<CheckboxViewModel>();
            foreach (var Item in _db.Items.ToList())
            {
                var item = new CheckboxViewModel()
                {
                    ItemId = Item.ItemId,
                    ItemName = Item.ItemName,
                    UnitPrice = Item.UnitPrice,
                    Category = Item.Category,
                    Checked = false, 
                    Qty = 0
                };

                items.Add(item);
            }

            model.items = items;
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult MakeOrders(MakeOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_db.UserInfos.FirstOrDefault(u => u.UserName.Equals(model.UserName)) is null)
                {
                    TempData["UserNotFound"] = ErrorMessageCommon.UserNotFound;
                    return RedirectToAction(nameof(MakeOrder));
                }
                else
                {
                    var targetUserName = _db.UserInfos.FirstOrDefault(u => u.UserName.Equals(model.UserName));

                    if (targetUserName.UserPassword == model.password)
                    {
                        var newOrder = new Order()
                        {
                            OrderDate = DateTime.Now,
                            OrderTime = DateTime.Now,
                            UserId = targetUserName.UserId,
                            UserName = targetUserName.UserName,
                            UserNumber = targetUserName.UserNumber
                        };
                        _db.Orders.Add(newOrder);

                        foreach (var item in model.items)
                        {
                            if (item.Checked)
                            {
                                var OrderDetailObj = new OrderDetail()
                                {
                                    ItemId = item.ItemId,
                                    ItemName = item.ItemName,
                                    Category = item.Category,
                                    UnitPrice = item.UnitPrice,
                                    Qty = item.Qty,
                                    Amount = item.UnitPrice * item.Qty,
                                    UserId = targetUserName.UserId

                                };
                                _db.OrderDetails.Add(OrderDetailObj);
                            }
                        }
                        _db.SaveChanges();
                        return RedirectToAction(nameof(ManageOrders), targetUserName);
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, ErrorMessageCommon.ModelStateErrorMessage);
                return View(nameof(MakeOrder));
            }
            return View(nameof(MakeOrder));
        }



        public IActionResult ManageOrders(UserInfo user)
        {
            ViewBag.Orders = _db.Orders.Where(order => order.UserId == user.UserId).ToList();
            ViewBag.OrderDetails = _db.OrderDetails.Where(orderDetail => orderDetail.UserId == user.UserId).ToList();

            return View();
        }
    }
}
