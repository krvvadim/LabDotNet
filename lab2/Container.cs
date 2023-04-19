using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Container
    {
        public List<HeadCurators> HeadCuratorList { get; set; }
        public List<Students> StudentList { get; set; }
        public List<Thesis> ThesisList { get; set; }
        public List<Discipline> DisciplineList { get; set; }
        public List<StudentDiscipline> StudentDisciplineList { get; set; }

        public Container()
        {

        }
    }
}
