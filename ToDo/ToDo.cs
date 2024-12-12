using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    
    public class ToDo
    {
        private static long idCoutner = 0;
        public static Queue<int> deletedIds = new Queue<int>();

        public long _id;
        public string title { get; set; }
        public string description {  get; set; }
        public TaskPriority priority { get; set; }
        public TaskStatus status { get; set; }
        public DateTime CreatedAt { get; set; }

        public ToDo(string description, string title, TaskPriority priority = TaskPriority.Low, TaskStatus status = TaskStatus.InProgress)
        {
            if(deletedIds.Count != 0)
            {
                _id = deletedIds.Dequeue();
            }
            else
            {
                _id = ++idCoutner;
            }

            this.description = description;
            this.title = title;
            this.priority = priority;
            this.status = status;
            CreatedAt = DateTime.Now;
        }

        public ToDo(long id, string description, string title, TaskPriority priority = TaskPriority.Low, TaskStatus status = TaskStatus.InProgress, DateTime dt)
        {
            _id = id;
            this.description = description;
            this.title = title;
            this.priority = priority;
            this.status = status;
            CreatedAt = dt;
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
    }
}
