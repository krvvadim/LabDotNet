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
        //public Students Student { get; set; }
        //public Discipline Discip { get; set; }

        public int StudID { get; set; }
        public int DiscID { get; set; }

        public StudentDiscipline() { }

        public StudentDiscipline(int studId, int discId)//(Students stud, Discipline disc)
        {
            StudID = studId;
            DiscID = discId;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID студента: {StudID}");
            sb.AppendLine($"ID дисципліни: {DiscID}");
            return sb.ToString();
        }

    }
}
