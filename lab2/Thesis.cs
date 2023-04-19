using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    //Клас Дипломна робота
    public class Thesis
    {
        public int ThesisID { get; set; }
        public string Title { get; set; }

        //Має поле для студента
        //public Students Student { get; set; }
        public int StudentID { get; set; }

        //Має поле для керівника
        //public HeadCurators HeadСurator { get; set; }
        public int CuratorID { get; set; }

        public Thesis() { }

        public Thesis(int thesisId, string title, int studentId, int curatorId) //Students student, HeadCurators headCurator)
        {
            ThesisID = thesisId;
            Title = title;
            StudentID = studentId;
            CuratorID = curatorId;
            //Student = student;
            //HeadСurator = headCurator;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID диплоної роботи: {ThesisID}");
            sb.AppendLine($"Назва: {Title}");
            sb.AppendLine($"Студент, що виконав: {StudentID}");
            sb.AppendLine($"Куратор: {CuratorID}");

            return sb.ToString();
        }

    }
}
