using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal class ConsoleManager
    {
        private ToDoPersistanceLayer _persistanceLayer;

        ConsoleManager() 
        {
            this._persistanceLayer = new ToDoPersistanceLayer();
        }
        public void run()
        {
            greetUser();
            displayMenuList();

            while (true)
            {
                Console.WriteLine("Please enter a valid command: ");
                int command = int.Parse(Console.ReadLine());

                switch(command)
                {
                    case (int)Commands.DisplayMenuList:
                        displayMenuList();
                        break;
                    case (int)Commands.CreateToDo:
                        createToDo();
                        break;
                    case (int)Commands.UpdateToDo:
                        updateToDo();
                        break;
                    case (int)Commands.DisplayToDoList:
                        displayToDoList();
                        break;
                    case (int)Commands.DisplayToDo:
                        displayToDo();
                        break;
                    case (int)Commands.DeleteToDo:
                        deleteToDo();
                        break;
                    case (int)Commands.TerminateSession:
                        terminateSession();
                        break;
                    default:
                        Console.WriteLine("Invalid command! Please enter a valid command");
                        break;
                }
                
                if((int)Commands.TerminateSession == command)
                {
                    break;
                }
            }
        }

        private void terminateSession()
        {
            Console.WriteLine("Thank you for your time. Have a nice day.");
        }

        private void deleteToDo()
        {
            Console.WriteLine("Please enter a id of ToDo to delete it.");
            int id = int.Parse((Console.ReadLine()));

            bool status = _persistanceLayer.deleteToDo(id);

            if(true == status)
            {
                Console.WriteLine($"ToDo with id=\"{id}\" is deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Error while deleteing the todo with id=\"{id}\".");
            }
        }

        private void displayToDo(long id = -1)
        {
            Console.WriteLine("Please enter a id of ToDo to delete it.");


            if (-1 == id)
            {
                id = long.Parse((Console.ReadLine()));
            }

            ToDo toDo = _persistanceLayer.getToDo(id);

            if(toDo != null)
            {
                Console.WriteLine($"Todo.Id = {toDo._id}");
                Console.WriteLine($"Todo.Title = {toDo.title}.");
                Console.WriteLine($"Todo.Description = {toDo.description}.");
                Console.WriteLine($"Todo.TaskPriority = {toDo.priority}.");
                Console.WriteLine($"Todo.TaskStatus = {toDo.status}.");
                Console.WriteLine($"Todo.CreatedAt = {toDo.CreatedAt}.");

            }
            else
            {
                Console.WriteLine($"Error while readinf the todo with id=\"{id}\".");
            }
        }

        private void displayToDoList()
        {

        }

        private void updateToDo()
        {
            throw new NotImplementedException();
        }

        private void createToDo()
        {
            throw new NotImplementedException();
        }

        private void displayMenuList()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Menu list: ");
            Console.WriteLine($"{Commands.DisplayMenuList}: To display menu list.");
            Console.WriteLine($"{Commands.CreateToDo}: To create a new ToDo.");
            Console.WriteLine($"{Commands.DisplayToDoList}: To display all ToDos.");
            Console.WriteLine($"{Commands.DisplayToDo}: To display a ToDo.");
            Console.WriteLine($"{Commands.UpdateToDo}: To update a ToDo");
            Console.WriteLine($"{Commands.DeleteToDo}: To delete a ToDo");
            Console.WriteLine($"{Commands.TerminateSession}: To terminate current session.");
            Console.WriteLine("---------------------------------------");
        }

        public void greetUser()
        {
            Console.WriteLine("Hello Wishtrian, welcome to ToDo app.\n");
        }

        

        private enum Commands
        {
            DisplayMenuList,
            CreateToDo,
            DisplayToDoList,
            DisplayToDo,
            UpdateToDo,
            DeleteToDo,
            TerminateSession
        }

    }
}
