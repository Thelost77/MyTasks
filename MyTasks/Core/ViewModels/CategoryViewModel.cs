using System;
using System.Collections.Generic;
using System.Linq;
using MyTasks.Core.Models.Domains;
namespace MyTasks.Core.ViewModels
{
    public class CategoryViewModel
    {
        public string Heading { get; set; }
        public Category Category { get; set; }

    }
}
