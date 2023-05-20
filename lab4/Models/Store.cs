using lab4.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class Store
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public Store()
        {
            Name = string.Empty;
            Products = new List<Product>();
        }
        public Store(string name)
        {
            Name = name;
            Products = new List<Product>();
        }
        public Store(string name, List<Product> products)
        {
            Name = name;
            Products = products;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void Show()
        {
            Console.WriteLine($"Назва магазину: {Name}. Кількість товарів: {Products.Count}.");
        }

        public void ShowAllProducts()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Products[i].Show();
                Console.WriteLine();
            }

        }

        public void ShowAllProductsWithNumbers()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                Products[i].Show();
                Console.WriteLine();
            }
        }
    }
}
