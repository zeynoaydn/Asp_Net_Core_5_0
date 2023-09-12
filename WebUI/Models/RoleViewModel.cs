using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen Rol Adı Giriniz")]
        public string name { get; set; }
    }
}
