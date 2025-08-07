using System.ComponentModel.DataAnnotations;

namespace TeamBalancer.UI.Components.TaskComponents
{
    public class TaskItem
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public TaskType TaskType { get; set; }

        public Guid? AssignedToId { get; set; }

        public double EstimatedHours { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }

    }
    public enum TaskType
    {
        [Display(Name = "פיתוח")]
        Development,

        [Display(Name = "בדיקות")]
        Testing,

        [Display(Name = "תיעוד")]
        Documentation,

        [Display(Name = "תכנון")]
        Design,

        [Display(Name = "מחקר")]
        Research,

        [Display(Name = "תחזוקה")]
        Maintenance,

        [Display(Name = "אחר")]
        Other
    }
}
