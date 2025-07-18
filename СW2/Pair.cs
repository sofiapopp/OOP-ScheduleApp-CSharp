using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СW2
{
    public class Pair : Class, IComparable<Pair>
    {
        private Teacher teacher;
        private StudentsGroup studentGroup;

        public Pair(string discipline, string lessonType, Date date, Time time, string location, Teacher teacher, StudentsGroup studentGroup)
            : base(discipline, lessonType, date, time, location)
        {
            this.teacher = teacher;
            this.studentGroup = studentGroup;
        }
        public Teacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }

        public StudentsGroup StudentGroup
        {
            get { return studentGroup; }
            set { studentGroup = value; }
        }



        public override void DisplayData()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| teacher: {0,17} | group: {1,14} |", Teacher.FullName, StudentGroup.GroupCode);


            base.DisplayData();

        }
        public override void SaveDataToFile(StreamWriter sw)
        {

            sw.WriteLine("------------------------------------------------------");
            sw.WriteLine($"| teacher: {Teacher.FullName,17} | group: {StudentGroup.GroupCode,14} |");

            base.SaveDataToFile(sw);

        }

        public int CompareTo(Pair other)
        {
            if (other == null)
            {
                return 1;
            }


            int yearComparison = this.Date.Year.CompareTo(other.Date.Year);
            int monthComparison = this.Date.Month.CompareTo(other.Date.Month);


            if (yearComparison == 0 && monthComparison == 0)
            {
                return this.Date.Day.CompareTo(other.Date.Day);
            }


            return (yearComparison != 0) ? yearComparison : monthComparison;
        }
    }
}
