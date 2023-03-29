using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="To Do")]
        public string ToDo { get; set; }

        [Display(Name = "Time")]
        public DateTime DateTime { get; set; }
    }
}
