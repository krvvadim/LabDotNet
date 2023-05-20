using lab4.Models.ProductModels.ComputerComponentsModels.Enums;
using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels
{
    public abstract class Product
    {
        public string Name { get; set; }
        public string Article { get; set; }
        public double Price { get; set; }
        public ProductCategory  Category { get; set; }

        public Product()
        {
            Name = string.Empty;
            Article = string.Empty;
            Price = 0;
            Category = new ProductCategory();
        }

        public Product(string name, string article, double price, ProductCategory category)
        {
            Name = name;
            Article = article;
            Price = price;
            Category = category;
        }

        public static string RAMTypeToString(RAMType type)
        {
            switch (type)
            {
                case RAMType.DDR1: return "DDR1";
                case RAMType.DDR2: return "DDR2";
                case RAMType.DDR3: return "DDR3";
                case RAMType.DDR4: return "DDR4";
                case RAMType.DDR5: return "DDR5";
                default: return "";
            }
        }

        public static string CoolerTypeToString(CoolerType type)
        {
            switch (type)
            {
                case CoolerType.Water: return "Water";
                case CoolerType.Tower: return "Tower";
            }

            return "";
        }

        public static string MatrixTypeToString(MatrixType type)
        {
            switch (type)
            {
                case MatrixType.IPS: return "IPS";
                case MatrixType.OLED: return "OLED";
                case MatrixType.TN: return "TN";
                case MatrixType.VA: return "VA";
                case MatrixType.TFT: return "TFT";
            }

            return "";
        }

        public static string MotherboardTypeToString(MotherboardType type)
        {
            switch (type)
            {
                case MotherboardType.ATX: return "ATX";
                case MotherboardType.MicroATX: return "Micro ATX";
                case MotherboardType.MiniATX: return "Mini ATX";
                default: return "";
            }
        }

        public abstract void Show();
    }
}
