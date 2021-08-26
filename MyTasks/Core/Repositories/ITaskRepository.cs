using MyTasks.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTasks.Core.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> Get(string userId, bool isExecuted = false, int categoryId = 0, string title = null);
        Task Get(int id, string userId);
        void Update(Task task);
        void Add(Task task);
        void Delete(int id, string userId);
        void Finish(int id, string userId);







    }
}
