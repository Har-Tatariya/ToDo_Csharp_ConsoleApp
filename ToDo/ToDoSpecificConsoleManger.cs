using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    public class ToDoSpecificConsoleManger
    {
        public void run()
        {
            greet();
            displayMenuList();

            while (true)
            {
                Console.WriteLine("Please enter a valid command: ");
                int command = int.Parse(Console.ReadLine());

                switch(command)
                {
                    case (int)ToDoCommands.DisplayToDoMenuList:
                        break;
                    case (int)ToDoCommands.CreateToDo:
                        break;
                    case (int)ToDoCommands.ReadToDo:
                        break;
                    case (int)ToDoCommands.UpdateToDo:
                        break;
                    case (int)ToDoCommands.DeleteToDo:
                        break;
                    case (int)ToDoCommands.TerminateToDoRunner:
                        break;
                    default:
                        Console.WriteLine("Invalid command! Please enter a valid command");
                        break;
                }
            }


        }

        private void greet()
        {
            Console.WriteLine("Wellcome to ToDo specific session.");
        }
        private void displayMenuList()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("ToDo specific Menu list: ");
            Console.WriteLine($"{ToDoCommands.DisplayToDoMenuList}: To display ToDo menu list.");
            Console.WriteLine($"{ToDoCommands.CreateToDo}: To create a new ToDo.");
            Console.WriteLine($"{ToDoCommands.ReadToDo} : To read a new ToDo.");
            Console.WriteLine($"{ToDoCommands.UpdateToDo}: To update a ToDo");
            Console.WriteLine($"{ToDoCommands.DeleteToDo}: To delete a ToDo");
            Console.WriteLine($"{ToDoCommands.TerminateToDoRunner}: To return to main session.");
            Console.WriteLine("---------------------------------------");
        }


         public void printToDo(ToDo toDo)
         {
            Console.WriteLine($"ToDo.Id: {toDo._id},");
            Console.WriteLine($"ToDo.Title: {toDo.title},");
            Console.WriteLine($"ToDo.Description: {toDo.description},");
            Console.WriteLine($"ToDo.Priority: {toDo.priority},");
            Console.WriteLine($"ToDo.CompletionStatus: {toDo.status},");
            Console.WriteLine($"ToDo.CreatedAt: {toDo.CreatedAt}.");
        }


        public enum ToDoCommands
        {
            DisplayToDoMenuList,
            CreateToDo,
            ReadToDo,
            UpdateToDo,
            DeleteToDo,
            TerminateToDoRunner
        }
    }
}
