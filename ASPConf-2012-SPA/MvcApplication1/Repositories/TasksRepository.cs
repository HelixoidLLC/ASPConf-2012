using System.Collections.Generic;
using MvcApplication1.Models;

namespace MvcApplication1.Repositories
{
    public static class TasksRepository
    {
        private static readonly List<Task> Tasks = new List<Task>();

        static TasksRepository()
        {
            Tasks.Add(new Task { Subject = "Vacuum floors"});
            Tasks.Add(new Task { Subject = "Water plants" });
        } 

        public static IEnumerable<Task> GetAll()
        {
            return Tasks;
        }

        public static void Add(Task task)
        {
            Tasks.Add(task);
        }
    }
}