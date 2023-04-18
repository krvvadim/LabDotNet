using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;

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

            List<HeadCurators> ListOfCurators = new List<HeadCurators>() {
                new HeadCurators(1, "Іванов Іван Іванович", "Доцент кафедри програмування"),
                new HeadCurators(2, "Петров Петро Петрович", "Професор кафедри програмування"),
                new HeadCurators(3, "Сидорова Анна Михайлівна", "Доцент кафедри інженерія"),
                new HeadCurators(4, "Ковальов Олексій Петрович", "Професор кафедри фізики"),
                new HeadCurators(5, "Лещенко Віталій Ігорович", "Професор кафедри історії"),
                new HeadCurators(6, "Павленко Олег Олександрович", "Доцент кафедри економіки")
            };

            List<Students> ListOfStudents = new List<Students>() {
                new Students(1, "Петренко Петро Петрович", "C1", new DateTime(2000, 1, 1), 90.3, ListOfCurators[0]),
                new Students(2, "Іваненко Іван Іванович", "C1", new DateTime(1999, 2, 18), 97.3, ListOfCurators[0]),
                new Students(3, "Василенко Василь Васильович", "C1", new DateTime(1998, 2, 10), 91.5, ListOfCurators[0]),
                new Students(4, "Кіт Іван Сергійович", "C1", new DateTime(2000, 8, 9), 93.3, ListOfCurators[1]),
                new Students(5, "Квітка Мілана Йосипівна", "A1", new DateTime(2000, 2, 3), 96.4, ListOfCurators[2]),
                new Students(6, "Чорний Степан Андрійович", "A3", new DateTime(2001, 12, 12), 98.9, ListOfCurators[3]),
                new Students(7, "Вишневський Андрій Данилович", "A1", new DateTime(2000, 1, 21), 90.7, ListOfCurators[4]),
                new Students(8, "Сосиска Миколай Ігоревич", "B1", new DateTime(1999, 11, 11), 95.8, ListOfCurators[5]),
                new Students(9, "Житній Олег Петрович", "C1", new DateTime(2000, 9, 4), 99.8, ListOfCurators[1]),
                new Students(10, "Самійленко Ірина Володимирівна", "D1", new DateTime(1998, 10, 3), 99.9, ListOfCurators[2]),
                new Students(11, "Нечепура Стефанія Григорівна", "B2", new DateTime(1999, 7, 2), 92.2, ListOfCurators[1]),
                new Students(12, "Борисенко Ольга Дмитрівна", "B3", new DateTime(2001, 1, 2), 94.9, ListOfCurators[2]),
                new Students(13, "Клин Богдан Вадимович", "D2", new DateTime(2000, 8, 10), 93.1, ListOfCurators[3]),
                new Students(14, "Черешня Артем Артемович", "B3", new DateTime(1999, 3, 29), 99.3, ListOfCurators[4]),
                new Students(15, "Солома Ярослав Романович", "C1", new DateTime(2002, 7, 2), 97.3, ListOfCurators[1])
            };

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create("students.xml", settings))
            {
                writer.WriteStartElement("students");
                foreach (Students student in ListOfStudents)
                {
                    writer.WriteStartElement("student");
                    writer.WriteElementString("StudentID", student.StudentID.ToString());
                    writer.WriteElementString("FullName", student.FullName);
                    writer.WriteElementString("Group", student.Group);
                    writer.WriteElementString("DateOfBirth", student.DateOfBirth.ToString("yyyy-MM-dd"));
                    writer.WriteElementString("AverageMark", student.AverageMark.ToString());
                    writer.WriteElementString("HeadCurator", student.Curator.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            List<Thesis> ListOfThesis = new List<Thesis>() {
                new Thesis(1, "Роль штучного інтелекту у сучасному світі", ListOfStudents[0], ListOfCurators[0]),
                new Thesis(2, "Веб-додаток", ListOfStudents[1], ListOfCurators[0]),
                new Thesis(3, "Аналіз мережевих атак на корпоративні системи", ListOfStudents[2], ListOfCurators[0]),
                new Thesis(4, "Розробка ігрової платформи з використанням віртуальної реальності", ListOfStudents[3], ListOfCurators[1]),
                new Thesis(5, "Розробка імітаційної моделі для вивчення технологій управління виробництвом", ListOfStudents[4], ListOfCurators[2]),
                new Thesis(6, "Розгляд астрономічних спостережень та експериментів, які допомагають збільшити знання про космос та розвиток Всесвіту", ListOfStudents[5], ListOfCurators[3]),
                new Thesis(7, "Перехід від феодалізму до капіталізму в Європі", ListOfStudents[6], ListOfCurators[4]),
                new Thesis(8, "Вплив COVID-19 на світову економіку", ListOfStudents[7], ListOfCurators[5]),
                new Thesis(9, "Розробка системи управління проектами на основі Agile методології", ListOfStudents[8], ListOfCurators[1]),
                new Thesis(10, "Аналіз та оптимізація процесу виробництва електронної продукції з використанням методів промислової інженерії", ListOfStudents[9], ListOfCurators[2]),
                new Thesis(11, "Створення програмного забезпечення для автоматизації бухгалтерського обліку", ListOfStudents[10], ListOfCurators[1]),
                new Thesis(12, "Проектування та розробка системи моніторингу та контролю якості виробництва на основі IoT-технологій", ListOfStudents[11], ListOfCurators[2]),
                new Thesis(13, "Дослідження фізичних властивостей наночастинок, їхньої структури та взаємодії з іншими матеріалами", ListOfStudents[12], ListOfCurators[3]),
                new Thesis(14, "Культурні взаємозв'язки між Сходом та Заходом", ListOfStudents[13], ListOfCurators[4]),
                new Thesis(15, "Використання блокчейн технологій в банківській сфері", ListOfStudents[14], ListOfCurators[1])
            };

            List<Discipline> ListOfDiscipline = new List<Discipline>() {
                new Discipline(1, "Програмування"),
                new Discipline(2, "Фізика"),
                new Discipline(3, "Інженерія"),
                new Discipline(4, "Економіка"),
                new Discipline(5, "Історія")
            };

            List<StudentDiscipline> ConnectStudDisc = new List<StudentDiscipline>() {
                new StudentDiscipline(ListOfStudents[0], ListOfDiscipline[0]),
                new StudentDiscipline(ListOfStudents[1], ListOfDiscipline[0]),
                new StudentDiscipline(ListOfStudents[2], ListOfDiscipline[0]),
                new StudentDiscipline(ListOfStudents[3], ListOfDiscipline[0]),
                new StudentDiscipline(ListOfStudents[4], ListOfDiscipline[2]),
                new StudentDiscipline(ListOfStudents[5], ListOfDiscipline[1]),
                new StudentDiscipline(ListOfStudents[6], ListOfDiscipline[4]),
                new StudentDiscipline(ListOfStudents[7], ListOfDiscipline[3]),
                new StudentDiscipline(ListOfStudents[8], ListOfDiscipline[0]),
                new StudentDiscipline(ListOfStudents[9], ListOfDiscipline[2]),
                new StudentDiscipline(ListOfStudents[10], ListOfDiscipline[0]),
                new StudentDiscipline(ListOfStudents[11], ListOfDiscipline[2]),
                new StudentDiscipline(ListOfStudents[12], ListOfDiscipline[1]),
                new StudentDiscipline(ListOfStudents[13], ListOfDiscipline[4]),
                new StudentDiscipline(ListOfStudents[14], ListOfDiscipline[0]),
                new StudentDiscipline(ListOfStudents[0], ListOfDiscipline[1]),
                new StudentDiscipline(ListOfStudents[1], ListOfDiscipline[2]),
                new StudentDiscipline(ListOfStudents[2], ListOfDiscipline[2]),
                new StudentDiscipline(ListOfStudents[3], ListOfDiscipline[3]),
                new StudentDiscipline(ListOfStudents[4], ListOfDiscipline[1]),
                new StudentDiscipline(ListOfStudents[5], ListOfDiscipline[0]),
                new StudentDiscipline(ListOfStudents[6], ListOfDiscipline[3]),
                new StudentDiscipline(ListOfStudents[7], ListOfDiscipline[2]),
                new StudentDiscipline(ListOfStudents[8], ListOfDiscipline[1]),
                new StudentDiscipline(ListOfStudents[9], ListOfDiscipline[4]),
                new StudentDiscipline(ListOfStudents[10], ListOfDiscipline[1]),
                new StudentDiscipline(ListOfStudents[11], ListOfDiscipline[4]),
                new StudentDiscipline(ListOfStudents[12], ListOfDiscipline[3]),
                new StudentDiscipline(ListOfStudents[13], ListOfDiscipline[2]),
                new StudentDiscipline(ListOfStudents[14], ListOfDiscipline[2])
            };

            XmlSerializer serializer = new XmlSerializer(typeof(List<Students>));

            using (TextWriter writer = new StreamWriter("studentss.xml"))
            {
                serializer.Serialize(writer, ListOfStudents);
            }

            using (TextReader reader = new StreamReader("studentss.xml"))
            {
                List<Students> studs = (List<Students>)serializer.Deserialize(reader);
                foreach (var student in studs)
                {
                    Console.WriteLine(student);
                }
            }
            XDocument data = XDocument.Load("studentss.xml");

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
                               .Where(r => Int32.Parse(r.Element("Curator").Element("HeadCuratorID").Value) == curatorID)
                               .Select(s => new
                               {
                                   StudentID = s.Element("StudentID").Value,
                                   FullName = s.Element("FullName").Value,
                                   Group = s.Element("Group").Value,
                                   DateOfBirth = DateTime.Parse(s.Element("DateOfBirth").Value),
                                   AverageMark = s.Element("AverageMark").Value,
                                   Curator = s.Element("Curator").Element("FullName").Value
                               });

            Console.WriteLine("\n4) Виведення студентів куратора з ID 1:");
            foreach (var student in query4)
            {
                Console.WriteLine($"ID студента: {student.StudentID}");
                Console.WriteLine($"ПІБ: {student.FullName}");
                Console.WriteLine($"Група: {student.Group}");
                Console.WriteLine($"Дата народження: {student.DateOfBirth.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Середня оцінка: {student.AverageMark}\n");
                Console.WriteLine($"Куратор: {student.Curator}\n");
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

            Console.WriteLine("\n6) Групування студентів по групам:\n");
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
                         join thesis in ListOfThesis on int.Parse((string)student.Element("StudentID").Value) equals thesis.Student.StudentID
                         join curator in ListOfCurators on thesis.HeadСurator.HeadCuratorID equals curator.HeadCuratorID
                         select new
                         {
                             ThesisTitle = thesis.Title,
                             StudentName = student.Element("FullName").Value,
                             StudentAverageGrade = student.Element("AverageMark").Value,
                             CuratorName = curator.FullName,
                             CuratorPosition = curator.Position
                         };
            Console.WriteLine($"\n9) Виведення інформації про дипломні роботи, хто виконав та хто керував:");
            foreach (var r in query9)
            {
                Console.WriteLine($"Student name: {r.StudentName}\nStudent average grade: {r.StudentAverageGrade}\nHead curator name: {r.CuratorName}\n" +
                    $"Head curator position: {r.CuratorPosition}\nThesis title: {r.ThesisTitle}\n");
            }

            // 10) Декартовий добуток між студентом та дисципліною
            var query10 = from c in ListOfCurators
                          from r in data.Descendants("Students")
                          select new { FullName = c.FullName, Fullname = r.Element("FullName").Value };

            Console.WriteLine("\n10)Декартовий добуток пасажирів та маршрутів:\n");
            foreach (var query in query10)
            {
                Console.WriteLine($"Студент: {query.FullName}. Куратор: {query.Fullname}\n");
            }

            // 11) Виведення студентів групуючи по групах і кураторах
            var query11 = from student in data.Descendants("Students")
                          group student by new { gr = student.Element("Group").Value, c = Int32.Parse(student.Element("Curator").Element("HeadCuratorID").Value) } into studentGroup
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
                           select new { FullName = student.Element("FullName").Value, AverageMark = (double)student.Element("AverageMark")}).Take(topFive);

            Console.WriteLine($"\n13) {topFive} кращих студентів:");
            foreach (var item in query13)
            {
                Console.WriteLine($"Ім'я: {item.FullName}. Середній бал: {item.AverageMark}");
            }
            Console.WriteLine();

            // 14) Студенти чоловіки
            var query14 = from student in data.Descendants("Students") where student.Element("FullName").Value.EndsWith("вич")
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
        }
    }
}
