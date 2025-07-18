using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СW2
{
    public class Date
    {
        private string day;
        private string month;
        private string year;


        public string Day
        {
            get { return day; }
            set { day = value; }
        }
        public string Month
        {
            get { return month; }
            set { month = value; }
        }

        public string Year
        {
            get { return year; }
            set { month = value; }
        }

        public Date(string day, string month, string year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public static Date GetValidDateInput()
        {
            string _dateinput;
            Date date;

            while (true)
            {
                Console.Write("Enter the day in the format dd.mm.yyyy : ");

                _dateinput = Console.ReadLine();

                if (IsValidDateFormat(_dateinput))
                {
                    string[] dateParts = _dateinput.Split('.');
                    date = new Date(dateParts[0], dateParts[1], dateParts[2]);
                    break;
                }

                Console.WriteLine("Invalid format. Try again.");
            }

            return date;
        }

        private static bool IsValidDateFormat(string input)
        {
            string[] dateParts = input.Split('.');

            if (dateParts.Length != 3)
            {
                return false;
            }

            if (int.TryParse(dateParts[0], out int day) && int.TryParse(dateParts[1], out int month) && int.TryParse(dateParts[2], out _))
            {
                if (day < 1 || day > 31)
                {
                    return false;
                }


                if (month < 1 || month > 12)
                {
                    return false;
                }


                return true;
            }


            return false;
        }

        public static bool operator ==(Date a, Date b)
        {
            return (a.Day == b.Day && a.Month == b.Month && a.Year == b.Year);
        }
        public static bool operator !=(Date a, Date b)
        {
            return !(a == b);
        }
    }
}
