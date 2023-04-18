using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    //Клас Керівник
    public class HeadCurators
    {
        public int HeadCuratorID { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }

        public HeadCurators () { }

        public HeadCurators(int headCuratorID, string fullName, string position)
        {
            HeadCuratorID = headCuratorID;
            FullName = fullName;
            Position = position;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID куратора: {HeadCuratorID}");
            sb.AppendLine($"ПІБ: {FullName}");
            sb.AppendLine($"Посада: {Position}");
            return sb.ToString();
        }
    }
}
