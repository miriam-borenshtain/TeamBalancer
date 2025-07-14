using TeamBalancer.API.Models.Domain;

namespace TeamBalancer.API.Models.DTO
{
    public class TeamDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public Guid? ManagerId { get; set; }


        //Navigation Property

        public Employee? Manager { get; set; }

    }
}
