using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using static ToDo.ToDo;

namespace ToDo
{
    public class ToDoPersistanceLayer
    {
        private static Dictionary <long, ToDo> _todos;
        private const string file = "todos.txt";
        public ToDoPersistanceLayer()
        {
            if ( _todos == null )
            {
                _todos = new Dictionary <long, ToDo>();

                /*if (File.Exists(file))
                {
                    // Store each line in array of strings 
                    string[] lines = File.ReadAllLines(file);

                    foreach (string toDoLine in lines)
                    {
                        ToDo toDo = convertStringToToDo(toDoLine);
                        _todos.Add(toDo._id, toDo);
                    }
                }*/
            }
        }
        /*
        private ToDo convertStringToToDo(string toDoLine)
        {

                        string[] toDoProperties = toDoLine.Split(',');
                        long id = long.Parse(toDoProperties[0]);
                        string title = toDoProperties[1];
                        string description = toDoProperties[2];
                        int priority = int.Parse(toDoProperties[3]);
                        int status = int.Parse(toDoProperties[4]);
                        string dateTime = toDoProperties[5];

                        TaskPriority taskPriority = (ToDo.TaskPriority)priority;
                        ToDo.TaskStatus taskStatus = (ToDo.TaskStatus)status;
                        DateTime dt = DateTime.Parse(dateTime);
                        ToDo toDo = new ToDo(id, title, description, dt, taskPriority, taskStatus);

                        return toDo;
        }
        */
        /*
        public string toCsv(ToDo toDo)
        {
            return $"{toDo._id},{toDo.title},{toDo.description},{(int)(toDo.priority)},{(int)(toDo.status)},{toDo.CreatedAt:o}";
        }
        */

        /*
        public void persist()
        {
            // implement logic to convert the todo into string and then write to file todo.txt.
            // Clear the file (or create it if it doesn't exist)
            
            File.WriteAllText(file, string.Empty);
            
            foreach (ToDo toDo in _todos.Values)
            {
                string line = toCsv(toDo);
                File.AppendAllText(file, line);
            }
            Console.WriteLine("Persist Method done.");
        }
        */
        public Dictionary <long, ToDo> getTodos()
        {
            return _todos;
        }

        public ToDo getToDo(long _id)
        {
            _todos.TryGetValue (_id, out var toDo);
            return toDo;
        }
        public bool saveToDo(string title, string description,  ToDo.TaskPriority priority, ToDo.TaskStatus status)
        {
            ToDo newToDo = new ToDo(title, description, priority, status);
            _todos.Add(newToDo._id, newToDo);
            return true;
        }

        public bool saveToDo(long id, string title, string description, DateTime dt, TaskPriority priority, ToDo.TaskStatus status)
        {
            ToDo newToDo = new ToDo(id, description, title, dt, priority, status);
            _todos.Add(newToDo._id, newToDo);
            return true;
        }

        public bool findToDo(long id)
        {
            return _todos.ContainsKey(id);
        }

        public bool deleteToDo(long _id)
        { 
            return _todos.Remove(_id);
        }

        public bool upadteToDoTitle(long _id, string newTitle)
        {
            _todos.TryGetValue(_id, out var toDo);

            if(toDo != null) 
            { 
                toDo.title = newTitle;
                return true;
            }
            return false;
        }

        public bool updateToDo(ToDo newToDo)
        {
            _todos[newToDo._id] = newToDo;
            return true;
        }

        internal enum CompletionStatus
        {
            InComplete,
            Complete
        }
    }
}

