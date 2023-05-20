using lab4.Models.ProductModels.ComputerComponentsModels.Enums;
using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels.ComputerComponentsModels
{
    public class RandomAccessMemory : Product
    {
        public int Memory { get; set; }
        public RAMType Type { get; set; }
        public RAMFormFactor FormFactor { get; set; }


        public RandomAccessMemory() : base()
        {
            Memory = 0;
            Type = new RAMType();
            FormFactor = new RAMFormFactor();
        }

        public RandomAccessMemory(string name, string article, double price, int memory, RAMType type, RAMFormFactor formFactor)
            : base(name, article, price, ProductCategory.RAM)
        {
            Memory = memory;
            Type = type;
            FormFactor = formFactor;
        }

        public RandomAccessMemory(string name, string article, double price, ProductCategory category, int memory, RAMType type, RAMFormFactor formFactor)
            : base(name, article, price, category)
        {
            Memory = memory;
            Type = type;
            FormFactor = formFactor;
        }

        public static string RAMFormFactorToString(RAMFormFactor formFactor)
        {
            switch (formFactor)
            {
                case RAMFormFactor.DIMM: return "DIMM";
                case RAMFormFactor.SO_DIMM: return "SO-DIMM";
                default: return "";
            }
        }

        public override void Show()
        {
            Console.WriteLine($"RAM: {Name}. Memory: {Memory}. Type: {RAMTypeToString(Type)}. Form-factor: {RAMFormFactorToString(FormFactor)}." +
                $" Type: Price: {Price.ToString("C")}. Article: {Article}.");
        }
    }
}
