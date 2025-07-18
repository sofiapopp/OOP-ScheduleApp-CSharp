using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace СW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string prompt = @"
             _     _      _       ___   ___   __     __    _      _  ____  ____  ___  
            | | | | |\ | | |     / / \ | |_) / /`_  / /\  | |\ | | |  / / | |_  | |_) 
            \_\_/ |_| \| |_|     \_\_/ |_| \ \_\_/ /_/--\ |_| \| |_| /_/_ |_|__ |_| \ 

            Welcome to your study organizer. Get started by creating a group.
            !Use the arrow keys to cycle through options and press enter to select an option!";

            string[] options = { "Create a group of students", "Display the list of students", "Create a schedule", "Display the schedule", "display occupied/unoccupied classrooms", "Add and display info about teachers", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            mainMenu.RunMainMenu();
            Console.ReadKey();

            //Student student1 = new Student ("Popp", 90.4);
            //XmlSerializer xmlser = new(typeof(Student));
            //Stream serialStream = new FileStream("student.xml", FileMode.Create);

            //xmlser.Serialize(serialStream, student1);
            //serialStream.Close();

            //serialStream = new FileStream("student.xml", FileMode.Open);

            //Student student2 = xmlser.Deserialize(serialStream) as Student;
            //serialStream.Close();
            //Console.WriteLine($"After XML deserialization: Name: {student2.Lastname}, Type: {student2.Rating}");

            //Teacher teacher1 = new Teacher("ISN", "Zavushchak I.I.", "docent");
            //Stream jsonfile = new FileStream("teacher.json", FileMode.Create);
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Teacher));
            //ser.WriteObject(jsonfile, teacher1);
            //jsonfile.Position = 0;
            //Teacher teacher2 = (Teacher)ser.ReadObject(jsonfile);
            //Console.WriteLine($"After JSON deserialization: Name: {teacher2.FullName}, Department: {teacher2.Department}, Year: {teacher2.Position}");
        }
    }
}