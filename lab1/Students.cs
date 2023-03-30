using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    //Клас Студент 
    public class Students
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public double AverageMark { get; set; }

        //public int CuratorID { get; set; }

        //зв'язок з Класом HeadCurators один-до-багатьох(один Керівник допомагає готувати диплом багатьом студентам)
        public HeadСurators Curator { get; set; }

        public Students(int studentId, string fullName, string group, DateOnly dateOfBirth, double averageMark, HeadСurators curator)
        {
            StudentID = studentId;
            FullName = fullName;
            Group = group;
            DateOfBirth = dateOfBirth;
            AverageMark = averageMark;
            //CuratorID = curatorId;
            Curator = curator;
        }

        //public override string ToString()
        //{
        //    return string.Format($"ID студента: {StudentID}\n" + $"ПІБ: {FullName}\n" +
        //        $"Група: {Group}\n" +
        //        $"Дата народження: {DateOfBirth}\n" +
        //        $"Середня оцінка: {AverageMark}\n" +
        //        $"Керівник: {Curator}\n");
        //}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID студента: {StudentID}");
            sb.AppendLine($"ПІБ: {FullName}");
            sb.AppendLine($"Група: {Group}");
            sb.AppendLine($"Дата народження: {DateOfBirth}");
            sb.AppendLine($"Середня оцінка: {AverageMark}");
            sb.AppendLine($"Керівник: {Curator.FullName}");
            return sb.ToString();
        }
    }

    public class DateOnly
    {
        private int day;
        private int month;
        private int year;

        public DateOnly(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public override string ToString()
        {
            return $"{day}.{month}.{year}";
        }
    }

}
