using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    /// <summary>
    /// Assignment 3
    /// </summary>
    public class Product
    {
        public int ProductCode { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Brand { get; set; }

        public Product()
        {

        }
        public Product(int code,string name,int qty, double price, double discount, string brand) 
        {
            this.ProductCode = code;
            this.Name = name;
            this.Quantity = qty;
            this.Price = price;
            this.Discount = discount;
            this.Brand = brand;
        }
    }

    public class ProductManager
    {
        private List<Product> products;
        public ProductManager()
        {
            products = new List<Product>
            {
                new Product(1, "Laptop", 10, 50000, 10, "Dell"),
                new Product(2, "Mobile", 20, 15000, 5, "Samsung"),
                new Product(3, "Headphones", 15, 2000, 20, "Sony")
            };
        }
        public void GetProductDetails()
        {
            Console.WriteLine("Enter product Code");
            int code = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter product Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product Quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter product Price");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter product Discount");
            double discount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter product Brand");
            string brand = Convert.ToString(Console.ReadLine());

            products.Add(new Product(code, name, quantity, price, discount, brand));

            Console.WriteLine("Product details added successfully");

        }

        public void DisplayProductDetails()
        {
            Console.WriteLine("Product Details");
            Console.WriteLine("--------------");

            foreach (var product in products)
            {
                Console.WriteLine($"Product code : {product.ProductCode}\nProduct Name : {product.Name}\nQuantity : {product.Quantity}" +
                    $"\nPrice of Product : {product.Price}" +
                    $"\nDiscount Allowed : {product.Discount}\nProduct Brand : {product.Brand}");
            }

        }

        public void CheckRole()
        {

            while (true)
            {
                Console.WriteLine("Welcome to Online shopping");
                Console.WriteLine("Please provide your role: \n1. Admin\n2.Customer");
                int role = int.Parse(Console.ReadLine());
                switch (role)
                {
                    case 1:
                        ShowAdminMenu();
                        break;
                    case 2:
                        ShowCustomerMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

        public void ShowAdminMenu()
        {
            while (true)
            {
                Console.WriteLine("Admin Menu");
                Console.WriteLine("-------------");
                Console.WriteLine("1. Add Product Details");
                Console.WriteLine("2. Show Product Details");
                Console.WriteLine("Please select your choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        GetProductDetails();
                        break;
                    case 2:
                        DisplayProductDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Exiting Application..");
                        break;
                }
            }
        }

        public void ShowCustomerMenu()
        {
            string name;
            int qty;
            Product productObj = new Product();

            Console.WriteLine("Enter product name want to purchase");
            name = Console.ReadLine().ToLower();
            Console.WriteLine("Enter quantity of product");
            qty = Convert.ToInt32(Console.ReadLine());

            bool isProductPresent = products.Any(p => p.Name.ToLower() == name);
            bool qtyPresent = productObj.Quantity <= qty;

            if (isProductPresent && qtyPresent)
            {
                productObj = products.Find(p => p.Name.ToLower() == name);

                /*var plist = products.Where(p => p.Name.ToLower().Contains(name)).ToList();

                if (plist.Count > 0)
                {
                    Console.WriteLine("Product found..");
                    foreach (var product in plist)
                    {
                    Console.WriteLine($"Product Name : {product.Name}\nQuantity : {product.Quantity}" +
                        $"\nPrice of Product : {product.Price}\nDiscount Allowed : {product.Discount}");
                    }

                }*/

                Console.WriteLine($"Product Name : {productObj.Name}\nQuantity : {productObj.Quantity}" +
                        $"\nPrice of Product : {productObj.Price}\nDiscount Allowed : {productObj.Discount}");

                Console.WriteLine("Proceed to Buy.. Y/N?");
                char customerChoice = Convert.ToChar(Console.ReadKey().KeyChar);

                if (char.ToLower(customerChoice) == 'y')
                {
                    CalculateAndPlaceOrderForCustomer(productObj,qty);
                }
                else
                {
                    Console.WriteLine("Exiting..");
                }

            }
            else
            {
                Console.WriteLine("No products were present right now!");
            }
        }

        void CalculateAndPlaceOrderForCustomer(Product product,int qty)
        {
            double totalPrice;

            totalPrice = product.Price - ((product.Discount / 100) * product.Price * qty);

            Console.WriteLine("\nOrder placed successfully!\n");
            Console.WriteLine("Product Summary\n---------------");
            Console.WriteLine($"Product Name : {product.Name}\nQuantity : {qty}" +
                    $"\nPrice of Product : {product.Price}\nDiscount Allowed : {product.Discount}");
            Console.WriteLine("-------------------");
            Console.WriteLine("Total Price : " + totalPrice);
        }
    }

}
