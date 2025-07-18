using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СW2
{
    public class Class
    {
        protected string discipline;
        protected string classType;
        protected Date date;
        protected Time time;
        protected string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        public Date Date
        {
            get { return date; }
            set { date = value; }
        }
        public Time Time
        {
            get { return time; }
            set { time = value; }
        }
        public string Discipline
        {
            get { return discipline; }
            set { discipline = value; }
        }

        public string ClassType
        {
            get { return classType; }
            set { classType = value; }
        }

        public Class(string discipline, string lessonType, Date date, Time time, string location)
        {
            this.discipline = discipline;
            this.classType = lessonType;
            this.date = date;
            this.time = time;
            this.location = location;
        }

        public virtual void DisplayData()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| discipline: {0,14} | classtype: {1,10} |", Discipline, ClassType);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| date:           {0,2}.{1,2}.{2,2} | time:           {3,2}:{4,2} |", Date.Day, Date.Month, Date.Year, Time.Hour, Time.Minute);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| location: {0,16} |                       |", Location);
            Console.WriteLine("------------------------------------------------------");


        }
        public virtual void SaveDataToFile(StreamWriter sw)
        {
            sw.WriteLine("------------------------------------------------------");
            sw.WriteLine($"| discipline: {Discipline,14} | classtype: {ClassType,10} |");
            sw.WriteLine("------------------------------------------------------");
            sw.WriteLine($"| date:           {Date.Day,2}.{Date.Month,2}.{Date.Year,2} | time:           {Time.Hour,2}:{Time.Minute,2} |");
            sw.WriteLine("------------------------------------------------------");
            sw.WriteLine($"| location: {Location,16} |                       |");
            sw.WriteLine("------------------------------------------------------");
        }
    }
}
