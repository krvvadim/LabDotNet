using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab4.Models.ProductModels.Enums;
using lab4.Models.ProductModels.ComputerComponentsModels.Enums;

namespace lab4.Models.ProductModels.ComputerComponentsModels
{
    public class VideoCard : Product
    {
        public int Memory { get; set; }
        public int Frequency { get; set; }
        public RAMType Type { get; set; }

        public VideoCard() : base()
        {
            Memory = 0;
            Frequency = 0;
            Type = new RAMType();
        }

        public VideoCard(string name, string article, double price, int memory, int frequency, RAMType type)
          : base(name, article, price, ProductCategory.VideoCard)
        {
            Memory = memory;
            Frequency = frequency;
            Type = type;
        }

        public VideoCard(string name, string article, double price, ProductCategory category, int memory, int frequency, RAMType type) 
            : base(name, article, price, category)
        {
            Memory = memory;
            Frequency = frequency;
            Type = type;
        }

        public override void Show()
        {
            Console.WriteLine($"Video card: {Name}. Memory: {Memory}. Frequency: {Frequency}. Type: {RAMTypeToString(Type)}." +
                $" Type: Price: {Price.ToString("C")}. Article: {Article}.");
        }
    }
}
