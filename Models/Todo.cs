using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Todo
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatingDate { get; set; }
    }
}
