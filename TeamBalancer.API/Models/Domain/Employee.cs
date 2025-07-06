namespace TeamBalancer.API.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; }

        public Guid TeamId { get; set; }

        //Navigation Property

        public Team Team { get; set; }

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    }
}
