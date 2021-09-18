using GradeBook.GradeBooks;
using System;

namespace GradeBook.UserInterfaces
{
    public static class GradeBookUserInterface
    {
        public static BaseGradeBook GradeBook;
        public static bool Quit;

        internal static void CommandLoop(BaseGradeBook gradeBook)
        {
            GradeBook = gradeBook;
            Quit = false;

            Console.WriteLine("#=======================#");
            Console.WriteLine(GradeBook.Name + " : " + GradeBook.GetType().Name);
            Console.WriteLine("#=======================#");

            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                UserInput(gradeBook);
            }
        }

        private static void CommandRoute(string command)
        {
            if (command == "save")
                SaveCommand();
            else if (command == "add")
                AddStudentCommand(command);
            else if (command == "statistics all")
                StatisticsCommand();
        }

        private static void AddStudentCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 4)
            {
                Console.WriteLine("Command not valid, Add requires a name, student type, and enrollment type.");
                return;
            }

            var name = parts[1];

        }
        public static void StatisticsCommand()
        {
            GradeBook.CalculateStatistics();
        }
        private static void SaveCommand()
        {
            GradeBook.Save();
            Console.WriteLine("{0} has been saved.", GradeBook.Name);
        }

        public static void UserInput(BaseGradeBook gradeBook)
        {
            GradeBook = gradeBook;
            Quit = false;

            Console.WriteLine(string.Empty);
            Console.WriteLine(">> How many students you want to add to this GradeBook ?");
            while (!Quit)
            {
                int studentsCount;
                var students = int.TryParse(Console.ReadLine().ToLower(), out studentsCount);
                while (!students)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Input a valid number!");
                    Console.WriteLine();

                    Console.Write("Given the value to add : ");
                    students = int.TryParse(Console.ReadLine(), out studentsCount);
                }
                NumberOfStudents(gradeBook, studentsCount);
            }
        }

        public static void NumberOfStudents(BaseGradeBook gradeBook, int studentsCount)
        {
            Console.WriteLine(">> Please input students information ?");
            for (int i = 0; i < studentsCount; i++)
            {
                Console.Write("First Name :");
                var fName = Console.ReadLine().ToLower();
                Console.Write("Last Name :");
                var lName = Console.ReadLine().ToLower();
                var student = new Student(fName, lName);
                gradeBook.AddStudent(student);
                Console.WriteLine();
                if (i != 1)
                {
                    Console.WriteLine("Next student...");
                }
                Console.WriteLine();
            }

            Console.WriteLine(">> how many tests were administered to the students? ");
            int testsAdministered;
            var numberOfTest = int.TryParse(Console.ReadLine().ToLower(), out testsAdministered);
            while (!numberOfTest)
            {
                Console.WriteLine();
                Console.WriteLine("Please Input a valid number!");
                Console.WriteLine();

                Console.Write("Given the value to add : ");
                numberOfTest = int.TryParse(Console.ReadLine(), out testsAdministered);
            }

            foreach (var student in gradeBook.Students)
            {
                Console.WriteLine($">> Please input grade for {student.FirstName + " " + student.LastName} ?");
                TestsWereAdministered(student, testsAdministered);
            }
            CommandRoute("statistics all");

        }

        public static void TestsWereAdministered(Student student, int testsAdministered)
        {
            for (int i = 1; i < testsAdministered + 1; i++)
            {
                double grade;
                Console.Write($"{i}. ");
                bool cekGrade = double.TryParse(Console.ReadLine().ToLower(), out grade);
                while (!cekGrade)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Input a valid grade!");
                    Console.WriteLine();

                    Console.Write("Given the grade to add : ");
                    cekGrade = int.TryParse(Console.ReadLine(), out testsAdministered);
                }

                student.AddGrade(grade);
            }
        }
    }
}
