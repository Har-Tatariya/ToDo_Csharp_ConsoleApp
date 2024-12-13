using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    public class ConsoleManager
    {
        private ToDoPersistanceLayer _persistanceLayer;
        private ToDoSpecificConsoleManger _toDoSpecificConsoleManger;
        public ConsoleManager() 
        {
            this._persistanceLayer = new ToDoPersistanceLayer();
            this._toDoSpecificConsoleManger = new ToDoSpecificConsoleManger();
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
                    // case (int)Commands.CreateToDo:
                    //    createToDo();
                    //    break;
                    // case (int)Commands.UpdateToDo:
                    //    updateToDo();
                    //    break;
                    case (int)Commands.DisplayToDoList:
                        displayToDoList();
                        break;
                    case (int)Commands.ToDoSplecificCRUD:
                        _toDoSpecificConsoleManger.run();
                        break;
                    // case (int)Commands.DisplayToDo:
                    //    displayToDo();
                    //   break;
                    // case (int)Commands.DeleteToDo:
                    //    deleteToDo();
                    //    break;
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
            // _persistanceLayer.persist();
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
            Dictionary <long, ToDo> todos = _persistanceLayer.getTodos();
            


            if(todos.Count > 0)
            {
                Console.WriteLine("All todo are: -------------------------");
                foreach(ToDo toDo in todos.Values)
                {
                    _toDoSpecificConsoleManger.printToDo(toDo);
                }
                Console.WriteLine("---------------all todos---------------");
            }
            else
            {
                Console.WriteLine("Yay!!! No ToDos for now.");
            }
        }

        

        private void displayMenuList()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("* Menu list: ");
            Console.WriteLine($"{(int)Commands.DisplayMenuList}: To display menu list.");
            // Console.WriteLine($"{Commands.CreateToDo}: To create a new ToDo.");
            Console.WriteLine($"{(int)Commands.DisplayToDoList}: To display all ToDos.");
            Console.WriteLine($"{(int)Commands.ToDoSplecificCRUD}: To perform operations on specific todo.");
            // Console.WriteLine($"{Commands.DisplayToDo}: To display a ToDo.");
            // Console.WriteLine($"{Commands.UpdateToDo}: To update a ToDo");
            // Console.WriteLine($"{Commands.DeleteToDo}: To delete a ToDo");
            Console.WriteLine($"{(int)Commands.TerminateSession}: To terminate current session.");
            Console.WriteLine("---------------------------------------");
        }

        public void greetUser()
        {
            Console.WriteLine("Hello Wishtrian, welcoooome to the ultimate ToDo app.\n");
        }

        

        private enum Commands
        {
            DisplayMenuList,
            // CreateToDo,
            DisplayToDoList,
            ToDoSplecificCRUD,
            // DisplayToDo,
            // UpdateToDo,
            // DeleteToDo,
            TerminateSession
        }

    }
}
