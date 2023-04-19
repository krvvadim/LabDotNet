using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using static System.Reflection.Metadata.BlobBuilder;

namespace lab2
{
    internal class Program
    {
        /*Розробити структуру даних для зберігання інформації про студентів-дипломників та їх керівників. 
          Про студентів необхідно зберігати щонайменше наступну інформацію: ПІБ, група, дата народження, середній бал. 
          Про керівників: ПІБ, посада. У одного керівника може бути декілька студентів-дипломників.*/

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            List<HeadCurators> headCurators = new List<HeadCurators>() {
                new HeadCurators(1, "Іванов Іван Іванович", "Доцент кафедри програмування"),
                new HeadCurators(2, "Петров Петро Петрович", "Професор кафедри програмування"),
                new HeadCurators(3, "Сидорова Анна Михайлівна", "Доцент кафедри інженерія"),
                new HeadCurators(4, "Ковальов Олексій Петрович", "Професор кафедри фізики"),
                new HeadCurators(5, "Лещенко Віталій Ігорович", "Професор кафедри історії"),
                new HeadCurators(6, "Павленко Олег Олександрович", "Доцент кафедри економіки")
            };

            List<Students> students = new List<Students>() {
                new Students(1, "Петренко Петро Петрович", "C1", new DateTime(2000, 1, 1), 90, headCurators[0].HeadCuratorID),
                new Students(2, "Іваненко Іван Іванович", "C1", new DateTime(1999, 2, 18), 97, headCurators[0].HeadCuratorID),
                new Students(3, "Василенко Василь Васильович", "C1", new DateTime(1998, 2, 10), 91, headCurators[0].HeadCuratorID),
                new Students(4, "Кіт Іван Сергійович", "C1", new DateTime(2000, 8, 9), 93, headCurators[1].HeadCuratorID),
                new Students(5, "Квітка Мілана Йосипівна", "A1", new DateTime(2000, 2, 3), 96, headCurators[2].HeadCuratorID),
                new Students(6, "Чорний Степан Андрійович", "A3", new DateTime(2001, 12, 12), 98, headCurators[3].HeadCuratorID),
                new Students(7, "Вишневський Андрій Данилович", "A1", new DateTime(2000, 1, 21), 90, headCurators[4].HeadCuratorID),
                new Students(8, "Сосиска Миколай Ігоревич", "B1", new DateTime(1999, 11, 11), 95, headCurators[5].HeadCuratorID),
                new Students(9, "Житній Олег Петрович", "C1", new DateTime(2000, 9, 4), 97, headCurators[1].HeadCuratorID),
                new Students(10, "Самійленко Ірина Володимирівна", "D1", new DateTime(1998, 10, 3), 99, headCurators[2].HeadCuratorID),
                new Students(11, "Нечепура Стефанія Григорівна", "B2", new DateTime(1999, 7, 2), 92, headCurators[1].HeadCuratorID),
                new Students(12, "Борисенко Ольга Дмитрівна", "B3", new DateTime(2001, 1, 2), 94, headCurators[2].HeadCuratorID),
                new Students(13, "Клин Богдан Вадимович", "D2", new DateTime(2000, 8, 10), 93, headCurators[3].HeadCuratorID),
                new Students(14, "Черешня Артем Артемович", "B3", new DateTime(1999, 3, 29), 92, headCurators[4].HeadCuratorID),
                new Students(15, "Солома Ярослав Романович", "C1", new DateTime(2002, 7, 2), 97, headCurators[1].HeadCuratorID)
            };


            List<Thesis> thesis = new List<Thesis>() {
                new Thesis(1, "Роль штучного інтелекту у сучасному світі", students[0].StudentID, headCurators[0].HeadCuratorID),
                new Thesis(2, "Веб-додаток", students[1].StudentID, headCurators[0].HeadCuratorID),
                new Thesis(3, "Аналіз мережевих атак на корпоративні системи", students[2].StudentID, headCurators[0].HeadCuratorID),
                new Thesis(4, "Розробка ігрової платформи з використанням віртуальної реальності", students[3].StudentID, headCurators[1].HeadCuratorID),
                new Thesis(5, "Розробка імітаційної моделі для вивчення технологій управління виробництвом", students[4].StudentID, headCurators[2].HeadCuratorID),
                new Thesis(6, "Розгляд астрономічних спостережень та експериментів, які допомагають збільшити знання про космос та розвиток Всесвіту", students[5].StudentID, headCurators[3].HeadCuratorID),
                new Thesis(7, "Перехід від феодалізму до капіталізму в Європі", students[6].StudentID, headCurators[4].HeadCuratorID),
                new Thesis(8, "Вплив COVID-19 на світову економіку", students[7].StudentID, headCurators[5].HeadCuratorID),
                new Thesis(9, "Розробка системи управління проектами на основі Agile методології", students[8].StudentID, headCurators[1].HeadCuratorID),
                new Thesis(10, "Аналіз та оптимізація процесу виробництва електронної продукції з використанням методів промислової інженерії", students[9].StudentID, headCurators[2].HeadCuratorID),
                new Thesis(11, "Створення програмного забезпечення для автоматизації бухгалтерського обліку", students[10].StudentID, headCurators[1].HeadCuratorID),
                new Thesis(12, "Проектування та розробка системи моніторингу та контролю якості виробництва на основі IoT-технологій", students[11].StudentID, headCurators[2].HeadCuratorID),
                new Thesis(13, "Дослідження фізичних властивостей наночастинок, їхньої структури та взаємодії з іншими матеріалами", students[12].StudentID, headCurators[3].HeadCuratorID),
                new Thesis(14, "Культурні взаємозв'язки між Сходом та Заходом", students[13].StudentID, headCurators[4].HeadCuratorID),
                new Thesis(15, "Використання блокчейн технологій в банківській сфері", students[14].StudentID, headCurators[1].HeadCuratorID)
            };

            List<Discipline> disciplines = new List<Discipline>() {
                new Discipline(1, "Програмування"),
                new Discipline(2, "Фізика"),
                new Discipline(3, "Інженерія"),
                new Discipline(4, "Економіка"),
                new Discipline(5, "Історія")
            };

            List<StudentDiscipline> connectStudDisc = new List<StudentDiscipline>() {
                new StudentDiscipline(students[0].StudentID, disciplines[0].DisciplineID),
                new StudentDiscipline(students[1].StudentID, disciplines[0].DisciplineID),
                new StudentDiscipline(students[2].StudentID, disciplines[0].DisciplineID),
                new StudentDiscipline(students[3].StudentID, disciplines[0].DisciplineID),
                new StudentDiscipline(students[4].StudentID, disciplines[2].DisciplineID),
                new StudentDiscipline(students[5].StudentID, disciplines[1].DisciplineID),
                new StudentDiscipline(students[6].StudentID, disciplines[4].DisciplineID),
                new StudentDiscipline(students[7].StudentID, disciplines[3].DisciplineID),
                new StudentDiscipline(students[8].StudentID, disciplines[0].DisciplineID),
                new StudentDiscipline(students[9].StudentID, disciplines[2].DisciplineID),
                new StudentDiscipline(students[10].StudentID, disciplines[0].DisciplineID),
                new StudentDiscipline(students[11].StudentID, disciplines[2].DisciplineID),
                new StudentDiscipline(students[12].StudentID, disciplines[1].DisciplineID),
                new StudentDiscipline(students[13].StudentID, disciplines[4].DisciplineID),
                new StudentDiscipline(students[14].StudentID, disciplines[0].DisciplineID),
                new StudentDiscipline(students[0].StudentID, disciplines[1].DisciplineID),
                new StudentDiscipline(students[1].StudentID, disciplines[2].DisciplineID),
                new StudentDiscipline(students[2].StudentID, disciplines[2].DisciplineID),
                new StudentDiscipline(students[3].StudentID, disciplines[3].DisciplineID),
                new StudentDiscipline(students[4].StudentID, disciplines[1].DisciplineID),
                new StudentDiscipline(students[5].StudentID, disciplines[0].DisciplineID),
                new StudentDiscipline(students[6].StudentID, disciplines[3].DisciplineID),
                new StudentDiscipline(students[7].StudentID, disciplines[2].DisciplineID),
                new StudentDiscipline(students[8].StudentID, disciplines[1].DisciplineID),
                new StudentDiscipline(students[9].StudentID, disciplines[4].DisciplineID),
                new StudentDiscipline(students[10].StudentID, disciplines[1].DisciplineID),
                new StudentDiscipline(students[11].StudentID, disciplines[4].DisciplineID),
                new StudentDiscipline(students[12].StudentID, disciplines[3].DisciplineID),
                new StudentDiscipline(students[13].StudentID, disciplines[2].DisciplineID),
                new StudentDiscipline(students[14].StudentID, disciplines[2].DisciplineID)
            };

            //adding all lists to container
            Container container = new Container();
            container.HeadCuratorList = headCurators;
            container.StudentList = students;
            container.ThesisList = thesis;
            container.DisciplineList = disciplines;
            container.StudentDisciplineList = connectStudDisc;

            string path = "data.xml";
            HelperXML.WriteDataToXml(container, path);

            Container containerFromFile = HelperXML.DeserializeFromXml(path);

            Console.WriteLine("===============================================");
            DispayToConsole.PrintToConsole(containerFromFile);
            Console.WriteLine("===============================================");

            // Loading file with XmlDocument.Load method
            XDocument data = XDocument.Load(path);

            Console.WriteLine("===============================================\nВиконання запитів: ");
            // 1) Виведення всіх студентів
            var query1 = from student in data.Descendants("Students")
                         select student.Element("FullName").Value;

            Console.WriteLine("\n1)Виведення імен всіх студентів:\n");
            foreach (var student in query1)
            {
                Console.WriteLine(student);
            }

            // 2) Виведення студенток
            var query2 = from girlStud in data.Descendants("Students")
                         where girlStud.Element("FullName").Value.EndsWith("івна")
                         select girlStud.Element("FullName").Value;

            Console.WriteLine("\n2)Виведення студентів жіночої статі:\n");
            foreach (var girl in query2)
            {
                Console.WriteLine(girl);
            }

            // 3) Виведення студентів за зростанням середнього балу
            var query3 = from student in data.Descendants("Students")
                         orderby student.Element("AverageMark").Value
                         select new
                         {
                             FullName = student.Element("FullName").Value,
                             Group = student.Element("Group").Value,
                             AverageMark = student.Element("AverageMark").Value
                         };

            Console.WriteLine("\n3)Виведення студентів за зростанням середнього балу:\n");
            foreach (var student in query3)
            {
                Console.WriteLine($"{student.FullName}, Group: {student.Group}, AverageMark: {student.AverageMark}");
            }

            // 4) Виведення студентів заданого куратора
            int curatorID = 1;

            var query4 = data.Descendants("Students")
                               .Where(r => Int32.Parse(r.Element("CuratorID").Value) == curatorID)
                               .Select(s => new
                               {
                                   StudentID = s.Element("StudentID").Value,
                                   FullName = s.Element("FullName").Value,
                                   Group = s.Element("Group").Value,
                                   DateOfBirth = DateTime.Parse(s.Element("DateOfBirth").Value),
                                   AverageMark = s.Element("AverageMark").Value,
                                   CuratorID = s.Element("CuratorID").Value
                               });

            Console.WriteLine("\n4) Виведення студентів куратора з ID 1:");
            foreach (var student in query4)
            {
                Console.WriteLine($"ID студента: {student.StudentID}");
                Console.WriteLine($"ПІБ: {student.FullName}");
                Console.WriteLine($"Група: {student.Group}");
                Console.WriteLine($"Дата народження: {student.DateOfBirth.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Середня оцінка: {student.AverageMark}\n");
                Console.WriteLine($"ID керівника: {student.CuratorID}\n");
            }

            // 5) Виведення студента, що має найбільший бал
            var query5 = from student in data.Descendants("Students")
                         orderby (double)student.Element("AverageMark") descending
                         select new
                         {
                             StudentID = (int)student.Element("StudentID"),
                             FullName = (string)student.Element("FullName"),
                             Group = (string)student.Element("Group"),
                             AverageMark = (double)student.Element("AverageMark")
                         };
            var studentWithHighestScore = query5.FirstOrDefault();
            Console.WriteLine("5) Student with highest score:");
            Console.WriteLine($"ID: {studentWithHighestScore.StudentID}");
            Console.WriteLine($"Full name: {studentWithHighestScore.FullName}");
            Console.WriteLine($"Group: {studentWithHighestScore.Group}");
            Console.WriteLine($"Average mark: {studentWithHighestScore.AverageMark}");

            // 6) Групування студентів по групам 
            var query6 = from student in data.Descendants("Students")
                         group student by student.Element("Group").Value;

            Console.WriteLine("\n6) Групування студентів по групам:");
            foreach (var temp in query6)
            {
                Console.WriteLine($"Шифр групи: {temp.Key}\nСтуденти:");
                foreach (var student in temp)
                {
                    Console.WriteLine(student.Element("FullName").Value);
                }
                Console.WriteLine();
            }

            // 7) Підрахунок студентів в заданій групі
            var gr = "C1";
            var query7 = (from student in data.Descendants("Students")
                          where student.Element("Group").Value == gr
                          select student).Count();


            Console.WriteLine($"7) Кількість студентів в групі {gr}: {query7}");

            // 8) Чи є студент в списку студентів
            string name = "Орищенко Сергій Іванович";
            var query8 = from student in data.Descendants("Students")
                         where student.Element("FullName").Value == name
                         select student;
            Console.WriteLine("\n8) Чи є студент {0} в списку студентів: {1}", name, (query8).Any() ? "Так" : "Ні");

            // 9) Виведення інформації про дипломні роботи, хто виконав та хто керував
            var query9 = from student in data.Descendants("Students")
                         join thes in data.Descendants("Thesis") on int.Parse((string)student.Element("StudentID").Value) equals int.Parse((string)thes.Element("StudentID"))
                         join curator in data.Descendants("HeadCurators") on int.Parse((string)thes.Element("CuratorID").Value) equals int.Parse((string)curator.Element("HeadCuratorID"))
                         select new
                         {
                             ThesisTitle = thes.Element("Title").Value,
                             StudentName = student.Element("FullName").Value,
                             StudentAverageGrade = student.Element("AverageMark").Value,
                             CuratorName = curator.Element("FullName").Value,
                             CuratorPosition = curator.Element("Position").Value
                         };
            Console.WriteLine($"\n9) Виведення інформації про дипломні роботи, хто виконав та хто керував:");
            foreach (var r in query9)
            {
                Console.WriteLine($"Student name: {r.StudentName}\nStudent average grade: {r.StudentAverageGrade}\nHead curator name: {r.CuratorName}\n" +
                    $"Head curator position: {r.CuratorPosition}\nThesis title: {r.ThesisTitle}\n");
            }

            // 10) Декартовий добуток між студентом та дисципліною
            var query10 = from c in data.Descendants("Discipline")
                          from r in data.Descendants("Students")
                          select new { FullName = r.Element("FullName").Value, Fullname = c.Element("Name").Value };

            Console.WriteLine("\n10)Декартовий добуток між студентом та дисципліною:\n");
            foreach (var query in query10)
            {
                Console.WriteLine($"Студент: {query.FullName}. Куратор: {query.Fullname}\n");
            }

            // 11) Виведення студентів групуючи по групах і кураторах
            var query11 = from student in data.Descendants("Students")
                          group student by new { gr = student.Element("Group").Value, c = Int32.Parse(student.Element("CuratorID").Value) } into studentGroup
                          select new
                          {
                              Group = studentGroup.Key.gr,
                              Curator = studentGroup.Key.c,
                              Students = studentGroup.Select(student => student.Element("FullName").Value).ToList()
                          };
            Console.WriteLine("\n11)Виведення студентів групуючи по групах і кураторах:");
            foreach (var group in query11)
            {
                Console.WriteLine($"Група: {group.Group} \nКерівник: {group.Curator} \nСтуденти: {string.Join(", ", group.Students)}\n");
            }

            // 12) Наймолодший студент
            var query12 = from student in data.Descendants("Students")
                          let dateOfBirth = (DateTime)student.Element("DateOfBirth")
                          orderby dateOfBirth descending
                          select new
                          {
                              StudentID = (int)student.Element("StudentID"),
                              FullName = (string)student.Element("FullName"),
                              Group = (string)student.Element("Group"),
                              DateOfBirth = dateOfBirth
                          };
            var theYoungestStudent = query12.First();
            Console.WriteLine("12) Наймолодший студент:");
            Console.WriteLine($"ID: {theYoungestStudent.StudentID}");
            Console.WriteLine($"Full name: {theYoungestStudent.FullName}");
            Console.WriteLine($"Group: {theYoungestStudent.Group}");
            Console.WriteLine($"Date of Birth: {theYoungestStudent.DateOfBirth.ToString("yyyy-MM-dd")}");

            // 13) Виведення топ-5 кращих студентів
            int topFive = 5;
            var query13 = (from student in data.Descendants("Students")
                           orderby (double)student.Element("AverageMark") descending, student.Element("FullName").Value
                           select new { FullName = student.Element("FullName").Value, AverageMark = (double)student.Element("AverageMark") }).Take(topFive);

            Console.WriteLine($"\n13) {topFive} кращих студентів:");
            foreach (var item in query13)
            {
                Console.WriteLine($"Ім'я: {item.FullName}. Середній бал: {item.AverageMark}");
            }
            Console.WriteLine();

            // 14) Студенти чоловіки
            var query14 = from student in data.Descendants("Students")
                          where student.Element("FullName").Value.EndsWith("вич")
                          select student.Element("FullName").Value;

            Console.WriteLine("\n14) Студенти чоловіки:\n");
            foreach (var boy in query14)
            {
                Console.WriteLine(boy);
            }

            //15) Виведення студентів за зростанням дати народження
            var query15 = from student in data.Descendants("Students")
                          orderby DateTime.Parse(student.Element("DateOfBirth").Value)
                          select new
                          {
                              FullName = student.Element("FullName").Value,
                              Group = student.Element("Group").Value,
                              DateOfBirth = DateTime.Parse(student.Element("DateOfBirth").Value)
                          };

            Console.WriteLine("\n15)Виведення студентів за зростанням дати народження:\n");
            foreach (var student in query15)
            {
                Console.WriteLine($"{student.FullName}, Group: {student.Group}, DateOfBirth: {student.DateOfBirth.ToString("yyyy-MM-dd")}");
            }

            // 16) Виведення посади керівників
            var result = from curator in data.Descendants("HeadCurators")
                         select curator.Element("Position").Value;

            Console.WriteLine("\n16)Виведення посади керівників: ");
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }

            // 17) Виведення дисциплін які відвідує певний студент
            var query17 = from sd in data.Descendants("StudentDiscipline")
                          join stud in data.Descendants("Students") on int.Parse((string)sd.Element("StudID").Value) equals int.Parse((string)stud.Element("StudentID"))
                          join disc in data.Descendants("Discipline") on int.Parse((string)sd.Element("DiscID").Value) equals int.Parse((string)disc.Element("DisciplineID"))
                          group disc.Element("Name").Value by stud.Element("FullName").Value into g
                          select new
                          {
                              StudList = g.Key,
                              DisciplineName = g.ToList()
                          };

            Console.WriteLine("\n17)Виведення студентів групуючи по групах і кураторах:");
            foreach (var g in query17)
            {
                Console.WriteLine($"Дисципліни студента {g.StudList}: {string.Join(", ", g.DisciplineName)}");
            }

            // 18) Виведення студентів групуючи кураторах

            var query19 = from student in data.Descendants("Students")
                          join curator in data.Descendants("HeadCurators") on int.Parse((string)student.Element("CuratorID").Value) equals int.Parse((string)curator.Element("HeadCuratorID"))
                          group student by new { c = Int32.Parse(student.Element("CuratorID").Value), n = (string)curator.Element("FullName").Value } into studentGroup
                          select new
                          {
                              HeadCuratorName = studentGroup.Key.n,
                              Students = studentGroup.Select(student => student.Element("FullName").Value).ToList()
                          };
            Console.WriteLine("\n19) Виведення студентів групуючи кураторів:");
            foreach (var group in query19)
            {
                Console.WriteLine($"Керівник: {group.HeadCuratorName}\nСтуденти: {string.Join(", ", group.Students)}\n");
            }

        }
    }
}
