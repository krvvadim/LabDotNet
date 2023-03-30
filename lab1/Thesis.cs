using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    //Клас Дипломна робота
    public class Thesis
    {
        public int ThesisID { get; set; }
        public string Title { get; set; }

        //Має поле для студента
        public Students Student { get; set; }

        //Має поле для керівника
        public HeadСurators HeadСurator { get; set; }

        public Thesis(int thesisId, string title, Students student, HeadСurators headCurator)
        {
            ThesisID = thesisId;
            Title = title;
            Student = student;
            HeadСurator = headCurator;
        }

        //public override string ToString()
        //{
        //    return string.Format($"ID диплоної роботи: {ThesisID}\n" + 
        //        $"Назва: {Title}\n" +
        //        $"Студент, що виконав: {Student}\n" +
        //        $"Куратор: {HeadСurator}\n");
        //}

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
