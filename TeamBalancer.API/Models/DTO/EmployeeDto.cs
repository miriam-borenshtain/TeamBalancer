using TeamBalancer.API.Models.Domain;

namespace TeamBalancer.API.Models.DTO
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; }

        //Navigation Property

        public TeamDto Team { get; set; }

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    }
}
