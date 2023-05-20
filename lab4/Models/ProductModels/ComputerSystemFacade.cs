using lab4.Models.ProductModels.ComputerComponentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels
{
    public static class ComputerSystemFacade
    {
        public static ComputerSystem AssembleComputerSystem(string name, string article, double price, List<Product> components, int purchase)
        {
            return new ComputerSystem(name, article, components, purchase);
        }
    }
}
