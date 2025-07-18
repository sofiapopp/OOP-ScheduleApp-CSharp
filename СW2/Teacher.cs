using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace СW2
{

    [Serializable]
    public class Teacher
    {
        
        private string department;
       
        private string fullName;
        
        private string position;

        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public Teacher() { }
        public Teacher(string fullName)
        {
            this.fullName = fullName;
        }
        public Teacher(string department, string fullName, string position)
        {
            this.fullName=fullName;
            this.department=department;
            this.position=position;
        }
        public static Teacher operator +(Teacher teacher, (string Department, string Position) values)
        {
            teacher.Department = values.Department;
            teacher.Position = values.Position;
            return teacher;
        }

        private static void TeacherInfo(Teacher teacher)
        {
            Console.WriteLine($"Add information about {teacher.FullName}");
            Console.Write("Enter the department: ");
            string _department = Console.ReadLine();
            Console.Write("Enter the position: ");
            string _position = Console.ReadLine();
            teacher += (_department, _position);
        }
        private void TeacherOutput()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Name: {0,23} | Department: {1,16} | Position: {2,18} |", FullName, Department, Position);
            Console.WriteLine("----------------------------------------------------------------------------------------------");

        }
        public static void AddInfoForTeacher(Schedule schedule)
        {
            IEnumerable<Teacher> teacherList =
                from pair in schedule.ScheduleList
                select pair.Teacher;
            foreach (Teacher teacher in teacherList)
            {
                Teacher.TeacherInfo(teacher);
            }

            foreach (Teacher teacher in teacherList)
            {
                teacher.TeacherOutput();
            }
        }
    }
}
