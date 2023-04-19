using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;

namespace lab2
{
    public static class HelperXML
    {
        //creating xml using XmlWriter
        public static void WriteDataToXml(Container container, string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            XmlWriter writer = XmlWriter.Create(path, settings);
            writer.WriteStartElement("Container");
            //writing HeadCurators
            writer.WriteStartElement("HeadCuratorList");
            foreach (HeadCurators headCur in container.HeadCuratorList)
            {
                writer.WriteStartElement("HeadCurators");
                writer.WriteElementString("HeadCuratorID", headCur.HeadCuratorID.ToString());
                writer.WriteElementString("FullName", headCur.FullName);
                writer.WriteElementString("Position", headCur.Position);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            //writing Students
            writer.WriteStartElement("StudentList");
            foreach (Students stud in container.StudentList)
            {
                writer.WriteStartElement("Students");
                writer.WriteElementString("StudentID", stud.StudentID.ToString());
                writer.WriteElementString("FullName", stud.FullName);
                writer.WriteElementString("Group", stud.Group);
                writer.WriteElementString("DateOfBirth", stud.DateOfBirth.ToString("yyyy-MM-dd"));
                writer.WriteElementString("AverageMark", stud.AverageMark.ToString());
                writer.WriteElementString("CuratorID", stud.CuratorID.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            //writing Theses
            writer.WriteStartElement("ThesisList");
            foreach (Thesis thes in container.ThesisList)
            {
                writer.WriteStartElement("Thesis");
                writer.WriteElementString("ThesisID", thes.ThesisID.ToString());
                writer.WriteElementString("Title", thes.Title);
                writer.WriteElementString("StudentID", thes.StudentID.ToString());
                writer.WriteElementString("CuratorID", thes.CuratorID.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            //writing Disciplines
            writer.WriteStartElement("DisciplineList");
            foreach (Discipline disc in container.DisciplineList)
            {
                writer.WriteStartElement("Discipline");
                writer.WriteElementString("DisciplineID", disc.DisciplineID.ToString());
                writer.WriteElementString("Name", disc.Name);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            //writing StudentDiscipline
            writer.WriteStartElement("StudentDisciplineList");
            foreach (StudentDiscipline sd in container.StudentDisciplineList)
            {
                writer.WriteStartElement("StudentDiscipline");
                writer.WriteElementString("StudID", sd.StudID.ToString());
                writer.WriteElementString("DiscID", sd.DiscID.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.Close();
        }
        //deserializing xml to Container object
        public static Container DeserializeFromXml(string path)
        {
            Container container;
            XmlSerializer serializer = new XmlSerializer(typeof(Container));
            using (StreamReader sr = new StreamReader(path))
            {
                container = (Container)serializer.Deserialize(sr);
            }
            return container;
        }
    }
}
