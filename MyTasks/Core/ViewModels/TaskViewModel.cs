using System;
using System.Collections.Generic;
using System.Linq;
using MyTasks.Core.Models.Domains;
namespace MyTasks.Core.ViewModels
{
    public class TaskViewModel
    {
        public string Heading { get; set; }
        public Task Task { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
