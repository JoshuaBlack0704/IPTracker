
using System.ComponentModel.DataAnnotations;

namespace UI.Client.FormModels
{
    public class UserForm
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}