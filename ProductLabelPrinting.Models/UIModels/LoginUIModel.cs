using System.ComponentModel.DataAnnotations;

namespace ProductLabelPrinting.Models.UIModel
{
    public class LoginUIModel
    {
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "User Name  should be between 4 and 10 characters")]
        public string UserName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Password should be between 4 and 10 characters")]
        public string Password { get; set; }
    }
}
