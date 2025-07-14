using System.ComponentModel.DataAnnotations;

namespace TeamBalancer.API.Models.DTO
{
    public class UpdateEmployeeDto
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public Guid TeamId { get; set; }


    }
}
