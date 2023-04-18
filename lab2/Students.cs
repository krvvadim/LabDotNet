using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization; 
using System.Threading.Tasks;

namespace lab2
{
    //Клас Студент 
    public class Students
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double AverageMark { get; set; }

        //зв'язок з Класом HeadCurators один-до-багатьох(один Керівник допомагає готувати диплом багатьом студентам)
        public HeadCurators Curator { get; set; }

        public Students() { }
        public Students(int studentId, string fullName, string group, DateTime dateOfBirth, double averageMark, HeadCurators curator)
        {
            StudentID = studentId;
            FullName = fullName;
            Group = group;
            DateOfBirth = dateOfBirth;
            AverageMark = averageMark;
            Curator = curator;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID студента: {StudentID}");
            sb.AppendLine($"ПІБ: {FullName}");
            sb.AppendLine($"Група: {Group}");
            sb.AppendLine($"Дата народження: {DateOfBirth.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Середня оцінка: {AverageMark}");
            sb.AppendLine($"Керівник: {Curator.FullName}");
            return sb.ToString();
        }
    }
}
