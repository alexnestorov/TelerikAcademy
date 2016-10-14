using System;
using System.Collections.Generic;
using System.Xml.Linq;

using XmlBasics.Enums;

namespace XmlBasics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();

            SeedStudents(students);

            var xmlDoc = CreateXmlDocument(students);

            Console.WriteLine(xmlDoc);
        }

        private static XDocument CreateXmlDocument(List<Student> students, string path = null)
        {
            XNamespace ns = "urn:students";
            if (path == null)
            {
                path = "../../../";
            }

            XDeclaration declaration = new XDeclaration("1.0", "utf-8", null);

            XDocument xml = new XDocument();

            xml.Declaration = declaration;
            xml.Add(new XProcessingInstruction(
                "xml-stylesheet",
                "type='text/xsl' href='students.xslt'"));


            var root = new XElement("students");
            xml.Add(root);

            root.SetAttributeValue(XNamespace.Xmlns + "student", ns);

            foreach (var student in students)
            {
                var studentElement = new XElement("student");

                studentElement.Add(new XAttribute("faculty-number", student.FacultyNumber));
                studentElement.Add(new XElement("name", student.Name));
                studentElement.Add(new XElement("gender", student.Gender));
                studentElement.Add(new XElement("birthday", student.Birthday.ToShortDateString()));
                studentElement.Add(new XElement("phone", student.Phone));
                studentElement.Add(new XElement("email", student.Email));
                studentElement.Add(new XElement("course", student.Course));
                studentElement.Add(new XElement("specialty", student.Specialty));

                var exams = new XElement("taken-exams");

                foreach (var exam in student.Exams)
                {
                    var examElement = new XElement("exam");
                    examElement.Add(new XElement("name", exam.Name));
                    examElement.Add(new XElement("tutor", exam.Tutor));
                    examElement.Add(new XElement("grade", exam.Score));
                    exams.Add(examElement);
                }

                studentElement.Add(exams);
                root.Add(studentElement);
            }

            xml.Save(path + "students.xml");
            return xml;
        }

        private static void SeedStudents(List<Student> students)
        {
            var st1 = new Student()
            {
                Name = "Ivan Ivanov",
                Gender = Gender.Male,
                Birthday = new DateTime(1990, 05, 05),
                Phone = "0888888888",
                Email = "ivan@abv.bg",
                Course = Course.Second,
                Specialty = Specialty.Economics,
                FacultyNumber = "23154",
                Exams = new List<Exam>()
                {
                    new Exam()
                    {
                        Name = "JS Exam",
                        Tutor = "Doncho Minkov",
                        Score = 6
                    }
                }
            };
            var st2 = new Student()
            {
                Name = "Petar Petrov",
                Gender = Gender.Male,
                Birthday = new DateTime(1982, 02, 13),
                Phone = "0777777111",
                Email = "pesho@yahoo.com",
                Course = Course.Fifth,
                Specialty = Specialty.Math,
                FacultyNumber = "12345",
                Exams = new List<Exam>()
                {
                    new Exam()
                    {
                        Name = "Mathematics",
                        Tutor = "Alexander Alexandrov",
                        Score = 6
                    },
                    new Exam()
                    {
                        Name = "Algebra",
                        Tutor = "Vasil Vasilev",
                        Score = 5
                    }
                }
            };

            var st3 = new Student()
            {
                Name = "Gergana Ivanova",
                Gender = Gender.Female,
                Birthday = new DateTime(1991, 10, 18),
                Phone = "0666666666",
                Email = "minka@gmail.com",
                Course = Course.Fourth,
                Specialty = Specialty.Physics,
                FacultyNumber = "12555",
                Exams = new List<Exam>()
                {
                    new Exam()
                    {
                        Name = "Physics Basics",
                        Tutor = "DONT KNOW",
                        Score = 6
                    },
                    new Exam()
                    {
                        Name = "Physics Advanced",
                        Tutor = "One-one",
                        Score = 6
                    }
                }
            };

            students.AddRange(new List<Student> { st1, st2, st3 });
        }
    }
}
