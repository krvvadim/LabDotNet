using lab4.Models.ProductModels.ComputerComponentsModels.Enums;
using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels.ComputerComponentsModels
{
    public class Case : Product
    {
        public MotherboardType FormFactor { get; set; }

        public Case() : base()
        {
            FormFactor = new MotherboardType();
        }

        public Case(string name, string article, double price, MotherboardType formFactor)
           : base(name, article, price, ProductCategory.Case)
        {
            FormFactor = formFactor;
        }

        public Case(string name, string article, double price, ProductCategory category, MotherboardType formFactor) 
            : base(name, article, price, category)
        {
            FormFactor = formFactor;
        }

        public override void Show()
        {
            Console.WriteLine($"Case: {Name}. Form factor: {MotherboardTypeToString(FormFactor)}. Price: {Price.ToString("C")}. Article: {Article}.");
        }
    }
}
