using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş bırakılmaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılmaz")]
        public string UserPassword { get; set; }
    }
}
