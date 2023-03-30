using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    //Клас для зв'язку між Студентами та Дисциплінами (багато-до-багатьох)
    public class StudentDiscipline
    {
        public Students Student { get; set; }
        public Discipline Discip { get; set; }
        //public int StudentID { get; set; }
        //public int DisciplineID { get; set; }

        public StudentDiscipline(Students stud, Discipline disc)
        {
            Student = stud;
            Discip = disc;

            //StudentID = studID;
            //DisciplineID = discID;
        }

        //public override string ToString()
        //{
        //    return string.Format($"ID студента: {StudentID}\n" + $"ID дисципліни: {DisciplineID}\n");
        //}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID студента: {Student.StudentID}");
            sb.AppendLine($"ID дисципліни: {Discip.DisciplineID}");
            return sb.ToString();
        }

    }
}
