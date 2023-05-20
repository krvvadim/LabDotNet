using lab4.Models.ProductModels.ComputerComponentsModels.Enums;
using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab4.Models.ProductModels.ComputerComponentsModels
{
    public class Monitor : Product
    {
        public double Diagonal { get; set; }
        public int Frequency { get; set; }
        public MatrixType MatrixType { get; set; }

        public Monitor() : base()
        {
            Diagonal = 0;
            Frequency = 0;
            MatrixType = new MatrixType();
        }

        public Monitor(string name, string article, double price, double diagonal, int frequency, MatrixType matrixType)
            : base(name, article, price, ProductCategory.Monitor)
        {
            Diagonal = diagonal;
            Frequency = frequency;
            MatrixType = matrixType;
        }

        public Monitor(string name, string article, double price, ProductCategory category, double diagonal, int frequency, MatrixType matrixType) 
            : base(name, article, price, category)
        {
            Diagonal = diagonal;
            Frequency = frequency;
            MatrixType = matrixType;
        }

        public override void Show()
        {
            Console.WriteLine($"Monitor: {Name}. Diagonal: {Diagonal}. Frequency: {Frequency}." +
                $" Matrix type: {MatrixTypeToString(MatrixType)}. Price: {Price.ToString("C")}. Article: {Article}.");
        }
    }
}
