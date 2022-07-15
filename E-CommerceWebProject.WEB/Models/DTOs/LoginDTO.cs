using System.ComponentModel.DataAnnotations;

namespace E_CommerceWebProject.WEB.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Bu alan bol bırakılamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
