using CafeManagementSystem.Common.AttributesErrorMessageCommon;
using CafeManagementSystem.Common.CommonExtensionMethods;
using CafeManagementSystem.Commons;
using CafeManagementSystem.DataLayer;
using CafeManagementSystem.ViewModel;
using CafeSystemManagement.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CafeManagementSystem.Areas.Admin.Controllers
{
    [Area(AreaAttributs.AreaAdmin)]
    public class ItemController : Controller
    {
        private readonly DataContext _db;
        public ItemController(DataContext dataContext)
        {
            _db = dataContext;
        }

        public IActionResult Index()
        {
           var items = _db.Items.ToList();
            return View(items);
        }

        public IActionResult Add()
        {
            ViewBag.Cats = _db.Categories.ToList();
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Add(AddItemViewModel newItem)
        {
            if (ModelState.IsValid)
            {
                var item = new Item()
                {
                    ItemName = newItem.ItemName,
                    Category = newItem.Category,
                    UnitPrice = newItem.UnitPrice,
                    AddedDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };
                _db.Items.Add(item);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, ErrorMessageCommon.ModelStateErrorMessage);
                return View();
            }
        }

         
        public IActionResult Edit(int id)
        {
             
            var targetItem = _db.Items.Find(int.Parse(id.ToString()));
            var model = new EditItemViewModel()
            {
                ItemName = targetItem.ItemName,
                Category = targetItem.Category,
                UnitPrice = targetItem.UnitPrice,
                ItemId = targetItem.ItemId
            };

            ViewBag.Cats = _db.Categories.ToList();
            return View(model); 
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(EditItemViewModel newItem)
        {
            if (ModelState.IsValid)
            {
                var item = _db.Items.Find(int.Parse(newItem.ItemId.ToString()));

                item.ItemName = newItem.ItemName;
                item.Category = newItem.Category;
                item.UnitPrice = newItem.UnitPrice;
                item.UpdateDate = DateTime.Now;
 
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, ErrorMessageCommon.ModelStateErrorMessage);
                ViewBag.Cats = _db.Categories.ToList();
                return View(newItem);
            }
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var targetItem = _db.Items.Find(int.Parse(id.ToString()));
                _db.Remove(targetItem);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ModelStateErrorText"] = ErrorMessageCommon.ModelStateErrorMessage;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
