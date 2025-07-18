using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace СW2
{
    public class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        public StudentsGroup studentgroup;
        public Schedule schedule;
        bool isStudentListCreated = false;
        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }
        private void DisplayOptions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Prompt);
            Console.WriteLine(" ");
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;
                if (i == SelectedIndex)
                {
                    prefix = "->";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix}  {currentOption}  ");
            }
            Console.ResetColor();
        }
        private int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }

        public void RunMainMenu()
        {

            int selectIndex = Run();
            switch (selectIndex)
            {
                case 0:
                    CreateGroupList();
                    break;
                case 1:
                    DispleyGroupList();
                    break;
                case 2:
                    CreateSchedule();
                    break;
                case 3:
                    DispleyScedual();
                    break;
                case 4:
                    DispleyRooms();
                    break;
                case 5:
                    AddInfoTeacher();
                    break;
                case 6:
                    Exit();
                    break;

            }
        }
        private void CreateGroupList()
        {
            Console.Clear();
            if (isStudentListCreated == false)
            {
                studentgroup = StudentsGroup.StudentsGroupInput();
                isStudentListCreated = (studentgroup != null && studentgroup.StudentsCount > 0);
                Console.WriteLine(" ");
                Console.WriteLine("Do you want to fill in the list of students?(enter 'yes' or 'later' )");
                string ginput = Console.ReadLine();
                Console.WriteLine(" ");
                if (Regex.IsMatch(ginput, "yes", RegexOptions.IgnoreCase))
                {
                    studentgroup.EditStudentList(studentgroup);
                    isStudentListCreated = false;
                }

            }
            else if (isStudentListCreated == true)
            {
                Console.WriteLine("");
                Console.WriteLine("Complete the list righе now");
                studentgroup.EditStudentList(studentgroup);
                isStudentListCreated = false;
            }
            Console.WriteLine(" ");
            Console.WriteLine(" > Press any key to return to the menu <");
            Console.ReadKey(true);
            RunMainMenu();
        }
        private void DispleyGroupList()
        {
            Console.Clear();
            if (studentgroup == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ! Pleace create a group first !");
                Console.ResetColor();
            }
            else
            {
                if (studentgroup.Students.Count() > 0)
                {
                    studentgroup.DisplayStudentList();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" ! Please create a group list first !");
                    Console.ResetColor();
                }
            }
            Console.WriteLine(" > Press any key to return to the menu <");
            Console.ReadKey(true);
            RunMainMenu();
        }
        private void CreateSchedule()
        {
            Console.Clear();

            if (studentgroup == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ! Pleace create a group first !");
                Console.ResetColor();

                Console.ReadKey(true);
                RunMainMenu();
            }
            schedule = new Schedule();
            schedule.EditScedule(schedule, studentgroup);
            Console.WriteLine(" ");
            Console.WriteLine(" > Press any key to return to the menu <");
            Console.ReadKey(true);
            RunMainMenu();
        }
        private void DispleyScedual()
        {
            Console.Clear();
            if (schedule == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! Please create a schedule first !");
                Console.ResetColor();
                Console.ReadKey(true);
                RunMainMenu();
            }
            schedule.DisplaySchedule();
            Console.ReadKey(true);
            RunMainMenu();
        }
        private void DispleyRooms()
        {
            Console.Clear();

            if (schedule == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! Please create a schedule first !");
                Console.ResetColor();
                Console.ReadKey(true);
                RunMainMenu();
            }
            Console.WriteLine(@"
╔═╗┬  ┌─┐┌─┐┌─┐┬─┐┌─┐┌─┐┌┬┐┌─┐
║  │  ├─┤└─┐└─┐├┬┘│ ││ ││││└─┐
╚═╝┴─┘┴ ┴└─┘└─┘┴└─└─┘└─┘┴ ┴└─┘
");
            Date simailardate = Date.GetValidDateInput();
            schedule.ClassRooms(simailardate);
            Console.WriteLine("");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
            RunMainMenu();
        }

        private void AddInfoTeacher()
        {
            Console.Clear();
            if (schedule == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! Please create a schedule first !");
                Console.ResetColor();
                Console.ReadKey(true);
                RunMainMenu();
            }
            Console.WriteLine(@"
╔╦╗┌─┐┌─┐┌─┐┬ ┬┌─┐┬─┐┌─┐
 ║ ├┤ ├─┤│  ├─┤├┤ ├┬┘└─┐
 ╩ └─┘┴ ┴└─┘┴ ┴└─┘┴└─└─┘
");
            Teacher.AddInfoForTeacher(schedule);
            Console.ReadKey(true);
            RunMainMenu();
        }
        private void Exit()
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);

        }
    }
}
