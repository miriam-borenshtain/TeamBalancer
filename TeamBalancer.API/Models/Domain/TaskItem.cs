using TeamBalancer.API.Models.Domain.Enums;

namespace TeamBalancer.API.Models.Domain
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


        //Navigation Property

        public Employee? AssignedTo {  get; set; }


    }
}
