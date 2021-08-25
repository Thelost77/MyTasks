using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MyTasks.Core.Models.Domains;
using MyTasks.Core.Models;
namespace MyTasks.Core.ViewModels
{
    public class TasksViewModel
    {
        public IEnumerable<Task> Tasks { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public FilterTask FilterTask { get; set; }
    }
}
