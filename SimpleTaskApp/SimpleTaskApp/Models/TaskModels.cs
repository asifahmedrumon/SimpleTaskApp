using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleTaskApp.Models
{
    public class TaskModels
    {
        [Key]
        public int IdTask { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string TaskName { get; set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public string CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public string UpdatedAt { get; set; }
    }
}