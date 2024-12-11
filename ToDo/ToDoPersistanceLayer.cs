using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal class ToDoPersistanceLayer
    {
        private Dictionary <long, ToDo> _todos;

        public Dictionary <long, ToDo> getAllTodos()
        {
            return _todos;
        }

        public ToDo getToDo(long _id)
        {
            return new ToDo("", "");
        }
        public bool addToDo(string title, string description)
        {
            ToDo newToDo = new ToDo(description, title);
            return true;
        }

        public bool deleteToDo(long _id)
        {
            return true;
        }

        public bool upadteToDo(string title, string description)
        {

            return true;
        }
    }
}

