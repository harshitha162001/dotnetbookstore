using Microsoft.AspNetCore.Mvc;
using Bulky.Models;
using Bulky.DataAccess.Data;


namespace Bulkyweb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "display order cannot exactly match to the name");

            }
            if (category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "test is an invalid value");

            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
              //category index redirect
            
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
           // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);
           // Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id == id).FirstOrDefault();
           if(categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
           
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
            //category index redirect

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);
            // Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id == id).FirstOrDefault();
            if (categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }
        [HttpPost ,ActionName("Delete")]
        public IActionResult DeletePost(int? id )
        {
            Category? obj = _db.Categories.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
          
            
            //category index redirect

        }
    }
}
