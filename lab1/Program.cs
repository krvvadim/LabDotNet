using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
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


            List<HeadСurators> ListOfCurators = new List<HeadСurators>() {
                new HeadСurators(1, "Іванов Іван Іванович", "Доцент кафедри програмування"),
                new HeadСurators(2, "Петров Петро Петрович", "Професор кафедри програмування"),
                new HeadСurators(3, "Сидорова Анна Михайлівна", "Доцент кафедри інженерія"),
                new HeadСurators(4, "Ковальов Олексій Петрович", "Професор кафедри фізики"),
                new HeadСurators(5, "Лещенко Віталій Ігорович", "Професор кафедри історії"),
                new HeadСurators(6, "Павленко Олег Олександрович", "Доцент кафедри економіки")
            };

            List<Students> ListOfStudents = new List<Students>() {
                new Students(1, "Петренко Петро Петрович", "C1", new DateOnly(1, 1, 2000), 90.3, ListOfCurators[0]),
                new Students(2, "Іваненко Іван Іванович", "C1", new DateOnly(18, 2, 1999), 97.3, ListOfCurators[0]),
                new Students(3, "Василенко Василь Васильович", "C1", new DateOnly(10, 2, 1998), 91.5, ListOfCurators[0]),
                new Students(4, "Кіт Іван Сергійович", "C1", new DateOnly(9, 8, 2000), 93.3, ListOfCurators[1]),
                new Students(5, "Квітка Мілана Йосипівна", "A1", new DateOnly(3, 2, 2000), 96.4, ListOfCurators[2]),
                new Students(6, "Чорний Степан Андрійович", "A3", new DateOnly(12, 12, 2001), 98.9, ListOfCurators[3]),
                new Students(7, "Вишневський Андрій Данилович", "A1", new DateOnly(21, 1, 2000), 90.7, ListOfCurators[4]),
                new Students(8, "Сосиска Миколай Ігоревич", "B1", new DateOnly(11, 11, 1999), 95.8, ListOfCurators[5]),
                new Students(9, "Житній Олег Петрович", "C1", new DateOnly(4, 9, 2000), 99.8, ListOfCurators[1]),
                new Students(10, "Самійленко Ірина Володимирівна", "D1", new DateOnly(3, 10, 1998), 100.0, ListOfCurators[2]),
                new Students(11, "Нечепура Стефанія Григорівна", "B2", new DateOnly(2, 7, 1999), 92.2, ListOfCurators[1]),
                new Students(12, "Борисенко Ольга Дмитрівна", "B3", new DateOnly(2, 1, 2001), 94.9, ListOfCurators[2]),
                new Students(13, "Клин Богдан Вадимович", "D2", new DateOnly(10, 8, 2000), 93.1, ListOfCurators[3]),
                new Students(14, "Черешня Артем Артемович", "B3", new DateOnly(29, 3, 1999), 99.3, ListOfCurators[4]),
                new Students(15, "Солома Ярослав Романович", "C1", new DateOnly(2002, 7, 19), 97.3, ListOfCurators[1])
            };

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

            // 1) Виведення всіх студентів
            Query1(ListOfStudents);

            // 2) Виведення студентів жіночої статі
            Query2(ListOfStudents);

            // 3) Виведення за зростанням середнього балу
            Query3(ListOfStudents);

            // 4) Виведення студентів куратора за заданим номером
            Query4(ListOfStudents, ListOfCurators, 1);

            // 5) Виведення дисциплін які відвідує певний студент
            Query5("Петренко Петро Петрович", ConnectStudDisc);

            // 6) Виведення назви Дипломної роботи, ПІБ керівника, який її вів і його посаду 
            Query6(ListOfCurators, ListOfThesis);

            // 7) Групування студентів по групам 
            Query7(ListOfStudents);

            // 8) Підрахунок студентів в заданій групі
            Query8(ListOfStudents, "C1");

            // 9) Виведення посади керівників
            Query9(ListOfCurators);

            // 10) Виведення даних про студента з найбільшим середнім балом
            Query10(ListOfStudents);

            // 11) Декартовий добуток між студентами і кураторами
            Query11(ListOfStudents, ListOfCurators);

            // 12) Виведення інформації про дипломні роботи, хто виконав та хто керував
            Query12(ListOfStudents, ListOfCurators, ListOfThesis);

            // 13) Виведення керівників доцентів
            Query13(ListOfCurators, "Д");

            // 14) Виведення середнього балу для кожної групи
            Query14(ListOfStudents);

            // 15) Виведення студентів групуючи по групах і кураторах
            Query15(ListOfStudents, ListOfCurators);

            // 16) Перевірка чи є дисципліна в списку дисциплін
            Query16(ListOfDiscipline, "Астрономія");

            //17) Кількість студентів в групі
            Query17(ListOfStudents);

            // 18) Виведення 5 кращих студентів
            Query18(ListOfStudents, 5);

            // 19) Студенти бал яких менше спільного середнього
            Query19(ListOfStudents);

            // 20) Перевірка чи є серед керівників хоч один старший науковий співробітник
            Query20(ListOfCurators);

            // 1) Виведення всіх студентів
            static void Query1(List<Students> students)
            {

                var result = from student in students
                             select student;

                Console.WriteLine("\n1)Виведення інформації про всіх студентів:\n");
                foreach (var student in result)
                {
                    Console.WriteLine(student);
                }
            }

            // 2) Виведення студенток
            static void Query2(List<Students> girlStudList)
            {

                var result = girlStudList.Where(t => t.FullName.EndsWith("івна"));

                Console.WriteLine("\n2)Виведення студентів жіночої статі:\n");
                foreach (var girl in result)
                {
                    Console.WriteLine(girl);
                }
            }

            // 3) Виведення студентів за зростанням середнього балу
            static void Query3(List<Students> students)
            {
                var result = from student in students
                             orderby student.AverageMark
                             select student;

                Console.WriteLine("\n3)Виведення студентів за зростанням середнього балу:\n");
                foreach (var student in result)
                {
                    Console.WriteLine(student);
                }
            }

            // 4) Виведення студентів заданого куратора
            static void Query4(List<Students> students, List<HeadСurators> curators, int IdOfCurator)
            {
                Console.WriteLine($"4) Виведення студентів {IdOfCurator}-го куратора:");

                var studentsOfCurator = from c in curators
                                        join s in students on c.HeadCuratorID equals s.Curator.HeadCuratorID
                                        where c.HeadCuratorID == IdOfCurator
                                        select s;

                foreach (var student in studentsOfCurator)
                {
                    Console.WriteLine(student.FullName);
                }
            }

            // 5) Виведення дисциплін які відвідує певний студент
            static void Query5(string name, List<StudentDiscipline> connect)
            {

                var student = connect.FirstOrDefault(x => x.Student.FullName == name)?.Student;

                var disciplines = connect.Where(x => x.Student == student).Select(x => x.Discip.Name).ToList();
                Console.WriteLine($"\n5) Виведення студентів і дисциплін, які вони відвідують:");
                if (disciplines == null)
                {
                    Console.WriteLine("Студент не знайдений");
                }
                else
                {
                    Console.WriteLine($"Дисципліни студента {name}: {string.Join(", ", disciplines)}");
                }
            }

            // 6) Виведення назви Дипломної роботи, ПІБ керівника, який її вів і його посаду
            static void Query6(List<HeadСurators> curators, List<Thesis> theses)
            {

                var result = from thesis in theses
                             join curator in curators on thesis.HeadСurator.FullName equals curator.FullName
                             select new { Title = thesis.Title, FullName = curator.FullName, Position = curator.Position };
                Console.WriteLine("\n6)Виведення назви Дипломної роботи, ПІБ керівника, який її вів і його посаду:");
                foreach (var temp in result)
                {
                    Console.WriteLine($"\nТема Дипломної роботи: {temp.Title}\n" + $"ПІБ куратора: {temp.FullName}\n" + $"Посада: {temp.Position}");
                    Console.WriteLine();
                }
            }

            // 7) Групування студентів по групам 
            static void Query7(List<Students> students)
            {

                var result = from student in students
                             group student by student.Group;

                Console.WriteLine("\n7)Групування студентів по групам:\n");
                foreach (var temp in result)
                {
                    Console.WriteLine($"Шифр групи: {temp.Key}\nСтуденти:");
                    foreach (var student in temp)
                    {
                        Console.WriteLine(student.FullName);
                    }
                    Console.WriteLine();
                }
            }

            // 8) Підрахунок студентів в заданій групі
            static void Query8(List<Students> students, string group)
            {

                var result = students.Count(s => s.Group == group);

                Console.WriteLine($"\n8)Кількість студентів в групі {group}: {result}");
            }

            // 9) Виведення посади керівників
            static void Query9(List<HeadСurators> сurators)
            {
                var result = from curator in сurators
                             select curator.Position;

                Console.WriteLine("\n9)Виведення посади керівників: ");
                foreach (var r in result)
                {
                    Console.WriteLine(r);
                }
            }

            // 10) Виведення даних про студента з найбільшим середнім балом
            static void Query10(List<Students> students)
            {
                var result = students.Where(s => s.AverageMark.Equals(students.Max(s => s.AverageMark)));
                Console.WriteLine("\n10)Виведення даних про студента з найбільшим середнім балом:");
                foreach (var student in result)
                {
                    Console.WriteLine(student);
                }
            }

            // 11) Декартовий добуток між студентами і кураторами
            static void Query11(List<Students> students, List<HeadСurators> curators)
            {
                var result = from student in students
                             from curator in curators
                             where student.Curator.FullName == curator.FullName
                             select new { StudentFullName = student.FullName, CuratorFullName = curator.FullName };

                Console.WriteLine("\n11)Декартовий добуток між студентами і кураторами:\n");
                foreach (var r in result)
                {
                    Console.WriteLine($"{r.StudentFullName} - {r.CuratorFullName}");
                }
            }

            // 12) Виведення інформації про дипломні роботи, хто виконав та хто керував
            static void Query12(List<Students> students, List<HeadСurators> curators, List<Thesis> theses)
            { 

                var result = from thesis in theses
                             join student in students on thesis.Student equals student
                             join curator in curators on thesis.HeadСurator equals curator
                             select new
                             {
                                 ThesisTitle = thesis.Title,
                                 StudentName = student.FullName,
                                 StudentAverageGrade = student.AverageMark,
                                 CuratorName = curator.FullName,
                                 CuratorPosition = curator.Position
                             };
                Console.WriteLine($"\n12) Виведення інформації про дипломні роботи, хто виконав та хто керував:");
                foreach (var r in result)
                {
                    Console.WriteLine($"Student name: {r.StudentName}\nStudent average grade: {r.StudentAverageGrade}\nHead curator name: {r.CuratorName}\n" +
                        $"Head curator position: {r.CuratorPosition}\nThesis title: {r.ThesisTitle}\n");
                }
            }

            // 13) Виведення керівників доцентів
            static void Query13(List<HeadСurators> curators, string str)
            {

                var result = curators.Where(p => p.Position.StartsWith(str)).ToList();

                Console.WriteLine("\n13)Виведення керівників доцентів:");

                if (result == null || result.Count == 0)
                {
                    Console.WriteLine("Керівника з такою посадою немає");
                }
                else
                {
                    foreach (var r in result)
                    {
                        Console.WriteLine(r);
                    }
                }
            }

            // 14) Виведення середнього балу для кожної групи
            static void Query14(List<Students> students)
            {

                var result = students.GroupBy(s => s.Group).OrderBy(g => g.Key)
                    .Select(g => new {
                        Group = g.Key,
                        AverageRating = g.Average(s => s.AverageMark)
                    });
                Console.WriteLine("\n14)Виведення середнього балу для кожної групи:");
                foreach (var r in result)
                {
                    Console.WriteLine($"Група: {r.Group}. Середній бал студентів: {r.AverageRating}");
                }
            }

            // 15) Виведення студентів групуючи по групах і кураторах
            static void Query15(List<Students> students, List<HeadСurators> curators)
            {
                var result = from student in students
                            group student by new { student.Group, student.Curator } into studentGroup
                            select new
                            {
                                Group = studentGroup.Key.Group,
                                Curator = studentGroup.Key.Curator.FullName,
                                Students = studentGroup.Select(student => student.FullName).ToList()
                            };
                Console.WriteLine("\n15)Виведення студентів групуючи по групах і кураторах:");
                foreach (var group in result)
                {
                    Console.WriteLine($"Група: {group.Group} \nКерівник: {group.Curator} \nСтуденти: {string.Join(", ", group.Students)}\n");
                }
            }

            // 16) Перевірка чи є дисципліна в списку дисциплін
            static void Query16(List<Discipline> discipline, string tdiscipline)
            {
                var result = (from d in discipline select d.Name).Contains(tdiscipline);
                Console.WriteLine(@"16)Чи є дисципліна {0} в списку дисциплін? : {1}", tdiscipline, (result ? "Так" : "Ні"));
                Console.WriteLine();
            }

            // 17) Кількість студентів в групі
            static void Query17(List<Students> students)
            {
                var result = students
                    .GroupBy(s => s.Group)
                    .OrderBy(g => g.Key)
                    .Select(g => new { Group = g.Key, Count = g.Count() });
                Console.WriteLine("17) Кількість студентів в групі");
                foreach (var count in result)
                {
                    Console.WriteLine($"Група: {count.Group}. Кількість студентів: {count.Count}");
                }
                Console.WriteLine();
            }

            // 18) Виведення топ-5 кращих студентів
            static void Query18(List<Students> students, int topFive)
            {
                var result = students
                     .OrderByDescending(s => s.AverageMark)
                     .ThenBy(s => s.FullName)
                     .Take(topFive);

                Console.WriteLine($"18) {topFive} кращих студентів:");
                foreach(var item in result)
                {
                    Console.WriteLine($"Ім'я: {item.FullName}. Середній бал: {item.AverageMark}");
                }
                Console.WriteLine();
            }

            // 19) Студенти бал яких менше спільного середнього
            static void Query19(List<Students> students)
            {
                double averageMark = students.Average(s => s.AverageMark);
                var result = students.Where(s => s.AverageMark < averageMark);
                Console.WriteLine($"19) Студенти бал яких менше середнього ( {Math.Round(averageMark, 3)} ):");
                foreach(var res in result)
                {
                    Console.WriteLine($"Ім'я: {res.FullName}. Середній бал: {res.AverageMark}. Дата народження: {res.DateOfBirth}");
                }
                Console.WriteLine();
            }

            // 20) Перевірка чи є серед керівників хоч один старший науковий співробітник
            static void Query20(List<HeadСurators> curators)
            {

                var result = curators.Any(p => p.Position == "Старший науковий співробітник");
                Console.WriteLine(@"20)Чи є серед керівників хоч один старший науковий співробітник? : {0}", (result ? "Так" : "Ні"));
            }
        }
    }
}
