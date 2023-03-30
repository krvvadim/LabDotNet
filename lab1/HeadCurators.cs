using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    //Клас Керівник
    public class HeadСurators
    {
        public int HeadCuratorID { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }

        public HeadСurators(int headCuratorID, string fullName, string position)
        {
            HeadCuratorID = headCuratorID;
            FullName = fullName;
            Position = position;
        }

        //public override string ToString()
        //{
        //    return string.Format($"ID куратора: {HeadCuratorID}\n" + $"ПІБ: {FullName}\n" +
        //        $"Посада: {Position}\n");
        //}

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
