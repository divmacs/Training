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
        public double Discount { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }

        List<Product> products = new List<Product>();
        public void GetProductDetails()
        {
            Product product = new Product();

            Console.WriteLine("Enter product Code");
            product.ProductCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter product Name");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter product Quantity");
            product.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter product Price");
            product.Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter product Discount");
            product.Discount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter product Brand");
            product.Brand = Convert.ToString(Console.ReadLine());

            products.Add(product);

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
            Product product = new Product();

            Console.WriteLine("Enter product name want to purchase");
            name = Console.ReadLine().ToLower();
            Console.WriteLine("Enter quantity of product");
            qty = Convert.ToInt32(Console.ReadLine());

            bool isProductPresent = products.Any(p => p.Name.ToLower() == name);
            bool qtyPresent = product.Quantity <= qty;

            if (isProductPresent && qtyPresent)
            {
                product = products.Find(p => p.Name.ToLower() == name);

                Console.WriteLine($"Product Name : {product.Name}\nQuantity : {product.Quantity}" +
                    $"\nPrice of Product : {product.Price}\nDiscount Allowed : {product.Discount}");

                Console.WriteLine("Proceed to Buy.. Y/N?");
                char customerChoice = Convert.ToChar(Console.ReadKey().KeyChar);

                if (char.ToLower(customerChoice) == 'y')
                {
                    CalculateAndPlaceOrderForCustomer(product);
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

        void CalculateAndPlaceOrderForCustomer(Product product)
        {
            double totalPrice;

            totalPrice = (product.Discount/100) * product.Price * product.Quantity;

            Console.WriteLine("Order placed successfully!\n");
            Console.WriteLine("Product Summary\n---------------");
            Console.WriteLine($"Product Name : {product.Name}\nQuantity : {product.Quantity}" +
                    $"\nPrice of Product : {product.Price}\nDiscount Allowed : {product.Discount}");
            Console.WriteLine("-------------------");
            Console.WriteLine("Total Price : " + totalPrice);
        }

    }
}
