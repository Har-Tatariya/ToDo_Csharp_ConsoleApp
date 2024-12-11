using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    
    internal class ToDo
    {
        static long idCoutner = 0;
        
        public long _id;
        public string description {  get; set; }
        public string title { get; set; }
        public TaskPriority priority { get; set; }
        public TaskStatus status { get; set; }
        public DateTime CreatedAt { get; set; }

        ToDo(string description, string title, TaskPriority priority = TaskPriority.Low, TaskStatus status = TaskStatus.InProgress)
        {
            _id = ++idCoutner;
            this.description = description;
            this.title = title;
            this.priority = priority;
            this.status = status;
            CreatedAt = DateTime.Now;
        }

        public ToDo(string description, string title)
        {
            this.description = description;
            this.title = title;
        }

        public enum TaskStatus
        {
            Pending,
            InProgress,
            Completed,
            Paused
        }


        public enum TaskPriority
        {
            Low,
            Medium,
            High
        }

        internal void print()
        {
            throw new NotImplementedException();
        }
    }
}
