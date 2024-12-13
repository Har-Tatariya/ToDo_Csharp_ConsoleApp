using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    public class ToDoSpecificConsoleManger
    {
        ToDoPersistanceLayer _persistanceLayer;

        public ToDoSpecificConsoleManger()
        {
            _persistanceLayer = new ToDoPersistanceLayer();
        }
        public void run()
        {
            greet();
            displayMenuList();

            while (true)
            {
                Console.WriteLine("Please enter a valid command: (0 for menu)");
                int command = int.Parse(Console.ReadLine());

                switch(command)
                {
                    case (int)ToDoCommands.DisplayToDoMenuList:
                        displayMenuList();
                        break;
                    case (int)ToDoCommands.CreateToDo:
                        createToDo();
                        break;
                    case (int)ToDoCommands.ReadToDo:
                        readToDo();
                        break;
                    case (int)ToDoCommands.UpdateToDo:
                        updateToDo();
                        break;
                    case (int)ToDoCommands.DeleteToDo:
                        deleteToDo();
                        break;
                    case (int)ToDoCommands.TerminateToDoRunner:
                        terminateCurrentSession();
                        break;
                    default:
                        Console.WriteLine("Invalid command! Please enter a valid command");
                        break;
                }

                if((int)ToDoCommands.TerminateToDoRunner == command)
                {
                    break;
                }
            }


        }

        private void terminateCurrentSession()
        {
            Console.WriteLine("Your todo specific task are done.");
        }

        private void deleteToDo()
        {
            Console.Write("Please enter the Id of Todo to delete: ");
            long id = long.Parse(Console.ReadLine());

            if(_persistanceLayer.findToDo(id))
            {
                Console.Write("Are you sure for deletetion: (y/n)");
                string confirmation = Console.ReadLine();
                if (confirmation[0] == 'y' || confirmation[0] == 'Y')
                {
                    _persistanceLayer.deleteToDo(id);
                    Console.WriteLine($"Todo with id={id} is been deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Deletetion of Todo with id={id} is aborted.");
                }
            }
            else
            {
                Console.WriteLine($"No Todo with id={id} found.");
            }
        }

        private void updateToDo()
        {
            Console.Write("Please enter the Id of Todo to update: ");
            long id = long.Parse(Console.ReadLine());

            if(_persistanceLayer.findToDo(id))
            {
                Console.WriteLine("Old todo is as follows: ");
                printToDo(_persistanceLayer.getToDo(id));
                Console.WriteLine("For updation, please enter all details again with new data.");
                createToDo(-1);
            }
            else
            {
                Console.WriteLine($"Sorry, no todo with id={id} found.");
            }
        }

        private void readToDo()
        {
            Console.Write("Please enter the Id of Todo to delete: ");
            long id = long.Parse(Console.ReadLine());

            if(_persistanceLayer.findToDo(id))
            {
                printToDo(_persistanceLayer.getToDo(id));
            }
            else
            {
                Console.WriteLine($"Sorry, no todo with id={id} found.");
            }
        }

        private void createToDo(long id = -1)
        {
            string title, description;
            ToDo.TaskPriority priority;
            ToDo.TaskStatus status;

            takeToDoInformation(out title, out description, out priority, out status);
            if (-1 == id)
            {
                _persistanceLayer.saveToDo(title, description, priority, status);

            }
            else
            {
                _persistanceLayer.saveToDo(id, title, description, DateTime.Now, priority, status);
            }
        }

        private void takeToDoInformation(out string title, out string description, out ToDo.TaskPriority priority, out ToDo.TaskStatus status)
        {
            Console.WriteLine("PLease enter the following details to for ToDo: ");
            Console.Write("Title: ");
            title = Console.ReadLine();
            Console.Write("Description: ");
            description = Console.ReadLine();
            Console.Write("For priority enter: 0: Low, 1: Medium, 2: High.");
            priority = (ToDo.TaskPriority) int.Parse(Console.ReadLine());
            status = ToDo.TaskStatus.InProgress;
        }

        private void greet()
        {
            Console.WriteLine("Wellcome to ToDo specific session.");
        }
        private void displayMenuList()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("* ToDo specific Menu list: ");
            Console.WriteLine($"{(int) ToDoCommands.DisplayToDoMenuList}: To display ToDo menu list.");
            Console.WriteLine($"{(int) ToDoCommands.CreateToDo}: To create a new ToDo.");
            Console.WriteLine($"{(int) ToDoCommands.ReadToDo} : To read a new ToDo.");
            Console.WriteLine($"{(int) ToDoCommands.UpdateToDo}: To update a ToDo");
            Console.WriteLine($"{(int) ToDoCommands.DeleteToDo}: To delete a ToDo");
            Console.WriteLine($"{(int) ToDoCommands.TerminateToDoRunner}: To return to main session.");
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
