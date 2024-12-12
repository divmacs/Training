using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreCRUDAssignment.Models;

namespace MVCCoreCRUDAssignment.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products;
        static ProductController()
        {
            products = new List<Product>()
            {
                new Product(){ProductCode = 101,ProductName = "Dell Laptop",Quantity = 5,Price = 45999 },
                new Product(){ProductCode = 102,ProductName = "Acer Laptop",Quantity = 10,
                    Price = 32999 },
                new Product(){ProductCode = 103,ProductName = "HP Laptop",Quantity = 3,
                    Price = 41999 },
                new Product(){ProductCode = 104,ProductName = "Lenevo Laptop",Quantity = 12,
                    Price = 43999 }

            };
        }
    

        // GET: ProductController
        public ActionResult Index()
        {
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductCode == id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product); 
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: ProductController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductCode == id);
            if (product != null)
                return View(product);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Product newProduct)
        {
            var product = products.FirstOrDefault(p => p.ProductCode == newProduct.ProductCode);
            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = newProduct.ProductName;
            product.Price = newProduct.Price;
            product.Quantity = newProduct.Quantity;

            return RedirectToAction("Index");
        }

        // GET: ProductController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductCode == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Delete (Post method to remove product)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductCode == id);
            if (product != null)
            {
                products.Remove(product);
            }

            return RedirectToAction("Index");
        }
    }
}
