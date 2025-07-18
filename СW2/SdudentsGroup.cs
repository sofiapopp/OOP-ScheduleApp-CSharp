using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СW2
{
    public class StudentsGroup
    {
        private string groupCode;
        private int studentsCount;
        private List<Student> students;

        public string GroupCode
        {
            get { return groupCode; }
            set { groupCode = value; }
        }

        public int StudentsCount
        {
            get { return studentsCount; }
            set { studentsCount = value; }
        }

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public StudentsGroup(string groupCode, int studentsCount)
        {
            this.groupCode = groupCode;
            this.studentsCount = studentsCount;
            students = new List<Student>(studentsCount);
        }


        public static StudentsGroup StudentsGroupInput()
        {
            Console.WriteLine("\r\n╦ ╦┌─┐┬ ┬  ┌─┐┬─┐┌─┐  ┌─┐┬─┐┌─┐┌─┐┌┬┐┬┌┐┌┌─┐  ┌─┐  ┌─┐┬─┐┌─┐┬ ┬┌─┐\r\n╚╦╝│ ││ │  ├─┤├┬┘├┤   │  ├┬┘├┤ ├─┤ │ │││││ ┬  ├─┤  │ ┬├┬┘│ ││ │├─┘\r\n ╩ └─┘└─┘  ┴ ┴┴└─└─┘  └─┘┴└─└─┘┴ ┴ ┴ ┴┘└┘└─┘  ┴ ┴  └─┘┴└─└─┘└─┘┴  \r\n                                                                  \r\r \r");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Group code: ");
            Console.ResetColor();
            string _groupCode = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"The number of students: ");
            Console.ResetColor();
            int _studentsCount = Convert.ToInt32(Console.ReadLine());
            StudentsGroup studentsgroup = new StudentsGroup(_groupCode, _studentsCount);
            return studentsgroup;
        }

        public static StudentsGroup operator +(StudentsGroup students, Student student)
        {
            students.Students.Add(student);
            return students;
        }
        public void EditStudentList(StudentsGroup students)
        {
            for (int i = 0; i < studentsCount; i++)
            {
                students += Student.StudentInput();
            }
        }
        public void DisplayStudentList()
        {
            Console.WriteLine(@"
╦ ╦┌─┐┬ ┬  ┌─┐┬─┐┌─┐  ┌┬┐┬┌─┐┌─┐┬  ┌─┐┬ ┬┬┌┐┌┌─┐  ┌┬┐┬ ┬┌─┐  ┌─┐┌┬┐┬ ┬┌┬┐┌─┐┌┐┌┬┐  ┬  ┬┌─┐┌┬┐
╚╦╝│ ││ │  ├─┤├┬┘├┤    │││└─┐├─┘│  ├─┤└┬┘│││││ ┬   │ ├─┤├┤   └─┐ │ │ │ ││├┤ ││││   │  │└─┐ │ 
 ╩ └─┘└─┘  ┴ ┴┴└─└─┘  ─┴┘┴└─┘┴  ┴─┘┴ ┴ ┴ ┴┘└┘└─┘   ┴ ┴ ┴└─┘  └─┘ ┴ └─┘─┴┘└─┘┘└┘┴   ┴─┘┴└─┘ ┴ 
");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Last name  | Rating   ");
            Console.ResetColor();
            Console.WriteLine(" ");
            foreach (var student in students)
            {
                student.StudentOutput();
            }
        }
    }
}
