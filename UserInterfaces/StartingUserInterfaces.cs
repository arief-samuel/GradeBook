using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.UserInterfaces
{
    public class StartingUserInterfaces
    {
        public static bool Quit = false;

        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(">> What would you lije to do");

                var command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }

        private static void CommandRoute(string command)
        {
            if (command.StartsWith("create"))
                CreateCommand(command);
            else if (command.StartsWith("load"))
                LoadCommand(command);
            else if (command.StartsWith("help"))
                HelpCommand();
            else if (command.StartsWith("quit"))
                Quit = true;
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }

        private static void CreateCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
                Console.WriteLine("Command not valid, Create requires a name.");
                return;

            var name = parts[1];
            BaseGradeBook GradeBook = new BaseGradeBook(name);

            Console.WriteLine("Created gradebook {0}.", name);
        }

        private static void HelpCommand()
        {
            throw new NotImplementedException();
        }

        private static void LoadCommand(string command)
        {
            throw new NotImplementedException();
        }
    }
}
