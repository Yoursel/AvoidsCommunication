using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AvoidsCommunication.Domain.ViewModel.Rambling
{
    public class RamblingViewModel
    {
        public int RamblingId { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите название")]
        [MinLength(4, ErrorMessage = "Минимальная длина должна быть больше 4 символов")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public IFormFile? Image { get; set; }

        public byte[]? Cover { get; set; }


        [Display(Name = "Статья")]
        [Required(ErrorMessage = "Введите статью")]
        [MinLength(60, ErrorMessage = "Минимальная длина должна быть больше 60 символов")]
        public string Content { get; set; }


        [Display(Name = "Тема")]
        [Required(ErrorMessage = "Выберите тему")]
        public string Topic { get; set; }

        public string? UserName { get; set; }

        public List<Entity.Comment>? Comments { get; set; }
    }
}
