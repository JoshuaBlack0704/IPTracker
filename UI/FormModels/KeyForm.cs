using System.ComponentModel.DataAnnotations;

namespace UI.Client.FormModels
{
    public class KeyForm
    {
        [Required]
        public string key { get; set; }
        [Required]
        public string alias { get; set; }
    }
}