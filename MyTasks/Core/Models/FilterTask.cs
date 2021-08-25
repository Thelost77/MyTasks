using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasks.Core.Models
{
    public class FilterTask
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }

        [Display(Name = "Tylko zrealizowane")]
        public bool IsExecuted { get; set; }
    }
}
