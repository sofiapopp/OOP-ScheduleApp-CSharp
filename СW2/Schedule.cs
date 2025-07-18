using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace СW2
{
    public class Schedule
    {
        private List<Pair> schedule;
        public Schedule()
        {
            schedule = new List<Pair>();  
        }
        public List<Pair> ScheduleList
        {
            get { return schedule; }
        }


        public void DisplaySchedule()
        {
            Console.WriteLine(@"
╦ ╦┌─┐┬ ┬  ┌─┐┬─┐┌─┐  ┌┬┐┬┌─┐┌─┐┬  ┌─┐┬ ┬┬┌┐┌┌─┐  ┌┬┐┬ ┬┌─┐  ┌─┐┌─┐┬ ┬┌─┐┌┬┐┬ ┬┬  ┌─┐
╚╦╝│ ││ │  ├─┤├┬┘├┤    │││└─┐├─┘│  ├─┤└┬┘│││││ ┬   │ ├─┤├┤   └─┐│  ├─┤├┤  │││ ││  ├┤ 
 ╩ └─┘└─┘  ┴ ┴┴└─└─┘  ─┴┘┴└─┘┴  ┴─┘┴ ┴ ┴ ┴┘└┘└─┘   ┴ ┴ ┴└─┘  └─┘└─┘┴ ┴└─┘─┴┘└─┘┴─┘└─┘
");
            schedule.Sort();
            Console.WriteLine(" ");
            foreach (var pair in schedule)
            {
                ScheduleOutput(pair);
                Console.WriteLine("");
            }

            Console.WriteLine();
            SaveScheduleToFile("Schedule.txt");
            Console.WriteLine("Do you want to open this file?(Enter 'yes' or 'no')");
            string openfile = Console.ReadLine();
            if (Regex.IsMatch(openfile, "yes", RegexOptions.IgnoreCase))
            {
                OpenScheduleFile("Schedule.txt");
            }
            Console.WriteLine("Do you want to empty this file?(Enter 'yes' or 'no')");
            string emptfile = Console.ReadLine();
            if (Regex.IsMatch(openfile, "yes", RegexOptions.IgnoreCase))
            {
                EmptyFile("Schedule.txt");
            }

        }
        private void EmptyFile(string fileName)
        {
            File.WriteAllText(fileName, string.Empty);

        }
        private void SaveScheduleToFile(string fileName)
        {
            try
            {
                using (StreamWriter sw = File.Exists(fileName) ? File.AppendText(fileName) : File.CreateText(fileName))
                {
                    sw.WriteLine("Schedule:");
                    sw.WriteLine(" ");
                    foreach (var pair in ScheduleList)
                    {
                        ScheduleFileOutput(pair, sw);
                    }
                }

                Console.WriteLine($"Schedule saved to {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving schedule to file: {ex.Message}");
            }
        }

        private void OpenScheduleFile(string fileName)
        {
            try
            {
                Process.Start("notepad.exe", fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening schedule file: {ex.Message}");
            }
        }
        public static Schedule operator +(Schedule schedule, Pair pair)
        {
            schedule.ScheduleList.Add(pair);
            return schedule;
        }

        public void EditScedule(Schedule schedule, StudentsGroup studentgroup)
        {
            Console.WriteLine(@"
╦ ╦┌─┐┬ ┬  ┌─┐┬─┐┌─┐  ┌─┐┬─┐┌─┐┌─┐┌┬┐┬┌┐┌┌─┐  ┌─┐  ┌─┐┌─┐┬ ┬┌─┐┌┬┐┬ ┬┬  ┌─┐
╚╦╝│ ││ │  ├─┤├┬┘├┤   │  ├┬┘├┤ ├─┤ │ │││││ ┬  ├─┤  └─┐│  ├─┤├┤  │││ ││  ├┤ 
 ╩ └─┘└─┘  ┴ ┴┴└─└─┘  └─┘┴└─└─┘┴ ┴ ┴ ┴┘└┘└─┘  ┴ ┴  └─┘└─┘┴ ┴└─┘─┴┘└─┘┴─┘└─┘
");
        schedulelink:
            Console.WriteLine("************************************");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("You cteate a part of schedule for discipline: ");
            Console.ResetColor();
            string discipline = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Please enter the techer`s name: ");
            Console.ResetColor();
            string teacherFullNsame = Console.ReadLine();
            Teacher teacher = new Teacher(teacherFullNsame);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Please enter the number of pairs: ");
            Console.ResetColor();
            int numberPairs = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberPairs; i++)
            {
                Console.WriteLine("--------------------------------------------------");

                Console.Write("Enter lesson type (lecture, practical, laboratory): ");
                string lessonType = Console.ReadLine();
                Date myDate = Date.GetValidDateInput();
                Time myTime = Time.GetValidTimeInput();
                Console.Write("Enter locatione(e.g. ducational building - auditorium): ");
                string location = Console.ReadLine();

                Pair pair = new Pair(discipline, lessonType, myDate, myTime, location, teacher, studentgroup);
                if (schedule != null)
                {
                    schedule += pair;
                }


            }
            Console.WriteLine("************************************");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Do you want to continue a filling-in the schedule?(Enter 'yes or 'no')");
            Console.ResetColor();
            string finput = Console.ReadLine();
            if (finput == "yes")
            {
                goto schedulelink;
            }
        }
        public void ClassRooms(Date date)
        {
            IEnumerable<Pair> datepairs =
                from pair in ScheduleList
                where (date == pair.Date)
                select pair;
            if (datepairs.Count() == 0)
            {
                Console.WriteLine("There are no pairs on this day. Try Again");
                return;
            }
            Time similartime = Time.GetValidTimeInput();
            IEnumerable<Pair> timepairs =
                from pair in datepairs
                where (similartime == pair.Time)
                select pair;
            IEnumerable<Pair> timenotpairs =
                from pair in datepairs
                where (similartime != pair.Time)
                select pair;

            Console.WriteLine("Occupied classrooms: ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Unoccupied classrooms ");
            Console.WriteLine("");
            foreach (var aud in timenotpairs)
            {
                Console.WriteLine(aud.Location);
                Console.WriteLine("--------");
            }
        }
        private void ScheduleOutput(Class x)
        {
            x.DisplayData();
            Console.WriteLine("");
        }
        private void ScheduleFileOutput(Class x, StreamWriter sw)
        {
            x.SaveDataToFile(sw);
        }
    }
}
