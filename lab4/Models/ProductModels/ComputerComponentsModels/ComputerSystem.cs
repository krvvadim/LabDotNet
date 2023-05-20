using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels.ComputerComponentsModels
{
    public class ComputerSystem : Product
    {
        public List<Product> Components { get; set; }
        public int PriceSurcharge { get; set; }

        public ComputerSystem() : base()
        {
            Components = new List<Product>();
        }

        public ComputerSystem(string name, string article, Processor processor,
            Motherboard motherboard, VideoCard videoCard, RandomAccessMemory ram, PowerSupplyUnit powerSupply, Case computerCase, int priceSurcharge)
            : base(name, article, 0, ProductCategory.ComputerConfiguration)
        {
            Components = new List<Product>();
            Components.Add(processor);
            Components.Add(motherboard);
            Components.Add(videoCard);
            Components.Add(ram);
            Components.Add(powerSupply);
            Components.Add(computerCase);

            PriceSurcharge = priceSurcharge;

            Price = GetPrice(); 
        }

        public ComputerSystem(string name, string article, List<Product> components, int priceSurcharge)
            : base(name, article, 0, ProductCategory.ComputerConfiguration)
        {
            Components = components;

            PriceSurcharge = priceSurcharge;

            Price = GetPrice();
        }

        public ComputerSystem(string name, string article, ProductCategory category, Processor processor,
            Motherboard motherboard, VideoCard videoCard, RandomAccessMemory ram, PowerSupplyUnit powerSupply, Case computerCase, int priceSurcharge)
            : base(name, article, 0, category)
        {
            Components.Add(processor);
            Components.Add(motherboard);
            Components.Add(videoCard);
            Components.Add(ram);
            Components.Add(powerSupply);
            Components.Add(computerCase);

            PriceSurcharge = priceSurcharge;

            Price = GetPrice();

        }

        private double GetPrice()
        {
            double totalPrice = 0;
            foreach (var component in Components)
            {
                totalPrice += component.Price;
            }

            return totalPrice * (1d + (PriceSurcharge / 100d));
        }

        public override void Show()
        {
            Console.WriteLine($"Computer System: {Name}. Price: {Price.ToString("C")}. Article: {Article}.\nComponents:");
            for (int i = 0; i < Components.Count; i++)
            {
                Components[i].Show();
            }
        }
    }
}
