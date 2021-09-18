using GradeBook.UserInterfaces;
using System;

namespace GradeBook
{
    class Program
    {
        public static object StartingUserInterface { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine("#=======================#");
            Console.WriteLine("# Welcome to GradeBook! #");
            Console.WriteLine("#=======================#");

            StartingUserInterfaces.CommandLoop();

            Console.WriteLine("Thank you for using GradeBook!");
            Console.WriteLine("Have a nice day!");
            Console.Read();
        }
    }
}
