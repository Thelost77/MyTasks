using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasks.Core.Models.Domains
{
    public class Task
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole tytuł jest wymagane")]
        [Display(Name = "Tytuł")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pole opis jest wymagane")]
        [Display(Name = "Opis")]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Pole kategoria jest wymagane")]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }

        [Display(Name = "Termin")]
        public DateTime? Term { get; set; }

        [Display(Name = "Zrealizowane")]
        public bool IsExecute { get; set; }
        public string UserId { get; set; }
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }

    }
}
