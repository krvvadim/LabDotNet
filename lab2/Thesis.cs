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
        public Students Student { get; set; }

        //Має поле для керівника
        public HeadCurators HeadСurator { get; set; }

        public Thesis() { }

        public Thesis(int thesisId, string title, Students student, HeadCurators headCurator)
        {
            ThesisID = thesisId;
            Title = title;
            Student = student;
            HeadСurator = headCurator;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID диплоної роботи: {ThesisID}");
            sb.AppendLine($"Назва: {Title}");
            sb.AppendLine($"Студент, що виконав: {Student.FullName}");
            sb.AppendLine($"Куратор: {HeadСurator.FullName}");

            return sb.ToString();
        }

    }
}
