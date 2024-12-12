using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDo
{
    internal class ToDoPersistanceLayer
    {
        private static Dictionary <long, ToDo> _todos;
        private const string file = "todos.txt";
        public ToDoPersistanceLayer()
        {
            if ( _todos == null )
            {
                _todos = new Dictionary <long, ToDo>();

                if (File.Exists(file))
                {
                    // Store each line in array of strings 
                    string[] lines = File.ReadAllLines(file);

                    foreach (string toDoLine in lines)
                    {
                        ToDo toDo = convertStringToToDo(toDoLine);
                        _todos.Add(toDo._id, toDo);
                    }
                }
            }
        }

        private ToDo convertStringToToDo(string toDoLine)
        {
            string[] toDoProperties = toDoLine.Split(',');
            long id = long.Parse(toDoProperties[0]);
            string title = toDoProperties[1];
            string description = toDoProperties[2];
            int priority = int.Parse(toDoProperties[3]);
            int status = int.Parse(toDoProperties[4]);
            string dateTime = toDoProperties[5];

            ToDo.TaskPriority taskPriority = (ToDo.TaskPriority)priority;
            ToDo.TaskStatus taskStatus = (ToDo.TaskStatus)status;
            DateTime dt = DateTime.Parse(dateTime);
            ToDo toDo = new ToDo(id, title, description, taskPriority, taskStatus, dt);
            
            return toDo;
        }

        public Dictionary <long, ToDo> getTodos()
        {
            return _todos;
        }

        public ToDo getToDo(long _id)
        {
            _todos.TryGetValue (_id, out var toDo);
            return toDo;
        }
        public bool createToDo(string title, string description,  ToDo.TaskPriority priority, ToDo.TaskStatus status)
        {
            ToDo newToDo = new ToDo(description, title, priority, status);  
            return true;
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

