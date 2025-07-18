using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СW2
{
    [Serializable]
    public class Student
    {
        private string lastname;
        private double rating;

        public string Lastname
        {
            set { lastname = value; }
            get { return lastname; }
        }

        public double Rating
        {
            set { rating = value; }
            get { return rating; }
        }
        public Student() { }
        public Student(string lastname, double rating)
        {
            this.lastname = lastname;
            this.rating = rating;

        }
        public static Student StudentInput()
        {
            Console.WriteLine("-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter student's lastname: ");
            Console.ResetColor();
            string _lastname = Console.ReadLine();
            double _rating;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter student's rating (not more than 100): ");
                Console.ResetColor();
                if (double.TryParse(Console.ReadLine(), out _rating) && _rating <= 100)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid rating (not more than 100).");
                    Console.ResetColor();
                }
            }
            Student student = new Student(_lastname, _rating);
            return student;
        }
        public void StudentOutput()
        {
            Console.WriteLine(" {0, -10} | {1, 10}", Lastname, Rating);
            Console.WriteLine(" ---------------------");
        }
    }
}
