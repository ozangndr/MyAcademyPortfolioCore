using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        [MinLength(5,ErrorMessage ="Proje Adı minimum 5 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Proje Adı maximum 50 karakter olmalıdır.")]
        [Required(ErrorMessage ="Proje adı boş bırakılamaz")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Proje açıklama boş bırakılamaz")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proje görsel url boş bırakılamaz")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Proje Github url boş bırakılamaz")]
        public string GithubUrl { get; set; }

        [Required(ErrorMessage = "Kategori boş bırakılamaz")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
