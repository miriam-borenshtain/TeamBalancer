namespace TeamBalancer.API.Models.Domain
{
    public class Team
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public Guid? ManagerId { get; set; }


        //Navigation Property

        public Employee? Manager { get; set; }

        public ICollection<Employee> Members { get; set; } = new List<Employee>();

    }
}
