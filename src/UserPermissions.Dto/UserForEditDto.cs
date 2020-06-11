using System.ComponentModel.DataAnnotations;

namespace UserPermissions.Dto
{
    public class UserForEditDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
    }
}