using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testCoreApp.Data;
using testCoreApp.Models;

namespace testCoreApp.Controllers
{
    public class ItemsController : Controller  
    {
        public ItemsController(AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db; 
        public IActionResult Index()
        {
            IEnumerable<Item> itemsList = _db.Items.ToList();
            return View(itemsList);
        }


        //GET
        public IActionResult New()
        {
            createSelectList();

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if(ModelState.IsValid)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                TempData["successData"] = "Item has been added successfully";

                return RedirectToAction("Index");


            }
            else { return View(item); 
            
            }

           
        }
        public void createSelectList(int selectId =0)
        {
            List<Category> categories = new List<Category>
            {
                 new Category(){Id= 0 , Name = "Select Category"},
                 new Category(){Id= 1 , Name = "Computers"},
                 new Category(){Id= 2 , Name = "Mobiles"},
                 new Category(){Id= 3 , Name = "Electric machines"},
            };
            SelectList listItems = new SelectList(categories, "Id", "Name", selectId);
            ViewBag.CategoryList = listItems;
        }
        //GET
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            createSelectList(item.CategoryId);
            return View(item);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (item.name == "100")
            {
                ModelState.AddModelError("Name", "Name can't equal 100");
            }
            if (ModelState.IsValid)
            {
                _db.Items.Update(item);
                _db.SaveChanges();
                TempData["successData"] = "Item has been Updated successfully";

                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }
        //GET
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            createSelectList(item.CategoryId);
            return View(item);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Item item)
        {
          
         
                _db.Items.Remove(item);
                _db.SaveChanges();
            TempData["successData"] = "Item has been Deleted successfully";

            return RedirectToAction("Index");
         
        }


    }
  


}