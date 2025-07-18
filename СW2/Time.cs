using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СW2
{
    public class Time
    {
        private string hour;
        private string minute;

        public string Hour
        {
            get { return hour; }
            set { hour = value; }
        }

        public string Minute
        {
            get { return minute; }
            set { minute = value; }
        }
        public Time(string hour, string minute)
        {

            this.hour = hour;
            this.minute = minute;
        }


        public static Time GetValidTimeInput()
        {
            string _timeinput;
            Time time;

            while (true)
            {
                Console.Write("Enter the time in the format hh:mm : ");

                _timeinput = Console.ReadLine();

                if (IsValidTimeFormat(_timeinput))
                {
                    string[] timeParts = _timeinput.Split(':');
                    time = new Time(timeParts[0], timeParts[1]);
                    break;
                }

                Console.WriteLine("Invalid format. Try again.");
            }

            return time;
        }

        private static bool IsValidTimeFormat(string input)
        {
            string[] timeParts = input.Split(':');

            if (timeParts.Length != 2)
            {
                return false;
            }

            if (int.TryParse(timeParts[0], out int hours) && int.TryParse(timeParts[1], out int minutes))
            {
                if (hours < 0 || hours > 23)
                {
                    return false;
                }


                if (minutes < 0 || minutes > 59)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public static bool operator ==(Time left, Time right)
        {
            return (left.Hour == right.Hour && left.Minute == right.Minute);
        }
        public static bool operator !=(Time left, Time right)
        {
            return !(left == right);
        }
    }
}
