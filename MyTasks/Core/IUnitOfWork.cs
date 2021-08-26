using MyTasks.Core.Repositories;
using MyTasks.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTasks.Core
{
    public interface IUnitOfWork
    {
        void Complete();
        ITaskRepository Task { get; set; }
        ICategoryRepository Category { get; set; }
    }
}
