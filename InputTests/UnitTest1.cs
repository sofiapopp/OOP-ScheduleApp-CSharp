using ÑW2;
namespace InputTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Sumoperator_studentandstudentsgroup_truereturned()
        {
            //arrange
            Student studenttest = new Student("Popp", 90.4);
            StudentsGroup studentsgrouptest = new StudentsGroup("SA-21", 29);
            //actual
            studentsgrouptest += studenttest;
            //assert
            CollectionAssert.Contains(studentsgrouptest.Students, studenttest);
        }
        [TestMethod]
        public void Sumoperator_scheduleandpair_truereturned()
        {
            //arrange
            Date datetest = new Date("12","12","2023");
            Time timetest = new Time("08","30");
            Teacher teachertest = new Teacher("Zavushchak I.I.");
            StudentsGroup studentsgrouptest = new StudentsGroup("SA-21", 29);
            Pair pair = new Pair("OOP", "lecture", datetest, timetest, "I-215", teachertest, studentsgrouptest);
            Schedule scheduletest = new Schedule();
            //actual
            scheduletest += pair;
            //assert
            CollectionAssert.Contains(scheduletest.ScheduleList, pair);
        }
        [TestMethod]
        public void Sumoperator_teacheranddepandpos_truereturned()
        {
            //arrange
            Teacher teachertest1 = new Teacher("ISN", "Zavushchak I.I.", "docent");
            Teacher testchertest2 = new Teacher("Zavushchak I.I.");
            testchertest2 += ("ISN", "docent");
            //actual
            bool teachersdepartments = teachertest1.Department == testchertest2.Department;
            bool teacherspositions = teachertest1.Position == testchertest2.Position;
            bool ectualteacher = teacherspositions && teachersdepartments;
            //assert
            Assert.IsTrue(ectualteacher);
        }
    }
}