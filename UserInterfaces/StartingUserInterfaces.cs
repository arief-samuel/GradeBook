using GradeBook.GradeBooks;
using System;

namespace GradeBook.UserInterfaces
{
    public static class StartingUserInterfaces
    {
        public static bool Quit = false;

        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(">> What would you like to do");
                Console.WriteLine(">> 1. Create new gradebook");
                Console.WriteLine(">> 2. Load existing gradebook ");
                Console.WriteLine(">> 3. Help");
                Console.WriteLine(">> 4. Quit");

                var command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }

        private static void CommandRoute(string command)
        {
            if (command.StartsWith("create") || command.StartsWith("1"))
            {
                string cmd = "create ";
                Console.Write("Please insert GradeBook name : ");
                string gbName = Console.ReadLine().ToLower();
                CreateCommand(cmd + gbName);
            }
            else if (command.StartsWith("load") || command.StartsWith("2"))
                LoadCommand(command);
            else if (command.StartsWith("help") || command.StartsWith("3"))
                HelpCommand();
            else if (command.StartsWith("quit") || command.StartsWith("4"))
                Quit = true;
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }

        private static void CreateCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2) { 
                Console.WriteLine("Command not valid, Create requires a name.");
                return;
            }

            var name = parts[1];
            BaseGradeBook GradeBook = new BaseGradeBook(name);

            Console.WriteLine("Created gradebook {0}.", name);

            GradeBookUserInterface.CommandLoop(GradeBook);
        }

        public static void HelpCommand()
        {
            Console.WriteLine();
            Console.WriteLine("GradeBook accepts the following commands:");
            Console.WriteLine();
            Console.WriteLine("Create 'Name' - Creates a new gradebook where 'Name' is the name of the gradebook.");
            Console.WriteLine();
            Console.WriteLine("Load 'Name' - Loads the gradebook with the provided 'Name'.");
            Console.WriteLine();
            Console.WriteLine("Help - Displays all accepted commands.");
            Console.WriteLine();
            Console.WriteLine("Quit - Exits the application");
        }

        private static void LoadCommand(string command)
        {
            throw new NotImplementedException();
        }
    }
}
