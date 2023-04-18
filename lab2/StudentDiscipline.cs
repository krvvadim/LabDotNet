using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    //Клас для зв'язку між Студентами та Дисциплінами (багато-до-багатьох)
    public class StudentDiscipline
    {
        public Students Student { get; set; }
        public Discipline Discip { get; set; }

        public StudentDiscipline() { }

        public StudentDiscipline(Students stud, Discipline disc)
        {
            Student = stud;
            Discip = disc;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID студента: {Student.StudentID}");
            sb.AppendLine($"ID дисципліни: {Discip.DisciplineID}");
            return sb.ToString();
        }

    }
}
