using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    //Клас Дисципліна
    public class Discipline
    {
        public int DisciplineID { get; set; }
        public string Name { get; set; }

        public Discipline(int disciplineId, string name)
        {
            DisciplineID = disciplineId;
            Name = name;
        }

        //public override string ToString()
        //{
        //    return string.Format($"ID університету: {DisciplineID}\n" + $"Назва: {Name}\n");
        //}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID дисципліни: {DisciplineID}");
            sb.AppendLine($"Назва: {Name}");

            return sb.ToString();
        }
    }
}
