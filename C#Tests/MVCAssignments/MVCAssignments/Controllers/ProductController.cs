using Microsoft.AspNetCore.Mvc;
using MVCAssignments.Models;

namespace MVCAssignments.Controllers
{
    public class ProductController : Controller
    {
        /*
            1. Pass 1 object using ViewBag
            2. Pass 5 products using ViewBag
            3. Pass 1 object directly to view
            4. Pass 5 products list directly to view
        */
        List<Product> products;
        public ProductController()
        {
            products = new List<Product>()
            {
                new Product(){ProductCode = 101,ProductName = "Dell Laptop",Quantity = 5,
                   DescriptionDetails = new string[]{"Brand: Dell","RAM: 8GB","SSD: 500GB","Model: Latitude3900","Processor: Intel i9"},
                    Price = 45999 },
                new Product(){ProductCode = 102,ProductName = "Acer Laptop",Quantity = 10,
                   DescriptionDetails = new string[]{"Brand: Acer","RAM: 8GB","SSD: 500GB","Model: Aspire 5","Processor: AMD Ryzen i5"},
                    Price = 32999 },
                new Product(){ProductCode = 103,ProductName = "HP Laptop",Quantity = 3,
                   DescriptionDetails = new string[]{"Brand: HP","RAM: 8GB","SSD: 500GB","Model: Chromebook","Processor: Intel i7"},
                    Price = 41999 },
                new Product(){ProductCode = 104,ProductName = "Lenevo Laptop",Quantity = 12,
                   DescriptionDetails = new string[]{"Brand: Lenevo","RAM: 8GB","SSD: 500GB","Model: ThinkPad","Processor: Intel i7"},
                    Price = 43999 }

            };
        }
        public IActionResult OneProduct()
        {
            Product product = new Product()
            {
                ProductCode = 100,
                ProductName = "Travel Bagpack",
                Quantity = 20,
                DescriptionDetails = new string[] { "Brand : Safari", "Year : 2024" },
                Price = 1599
            };
            //ViewBag.Product = product;
            return View(product);
        }

        public IActionResult ProductsList()
        {
            ViewBag.Products = products;
            return View();
        }
    }
}
