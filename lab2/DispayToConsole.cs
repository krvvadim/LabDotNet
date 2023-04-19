using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public static class DispayToConsole
    {
        public static void PrintToConsole(Container container)
        {
            DisplayListOfObjects("HeadCuratorList", container.HeadCuratorList);
            DisplayListOfObjects("StudentList", container.StudentList);
            DisplayListOfObjects("ThesisList", container.ThesisList);
            DisplayListOfObjects("DisciplineList", container.DisciplineList);
            DisplayListOfObjects("StudentDisciplineList", container.StudentDisciplineList);
        }
        public static void DisplayListOfObjects<T>(string listName, List<T> list)
        {
            Console.WriteLine($"{listName}:");
            foreach (var item in list)
                Console.WriteLine($"\t{item}");
        }
    }
}
