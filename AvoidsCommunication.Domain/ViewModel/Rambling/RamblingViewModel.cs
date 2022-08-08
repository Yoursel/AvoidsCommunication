using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidsCommunication.Domain.ViewModel.Rambling
{
    public class RamblingViewModel
    {
        //public int RamblingId { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите название")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public byte[]? Cover { get; set; }


        [Display(Name = "История")]
        [Required(ErrorMessage = "Статья не может быть пустой")]
        [MinLength(30, ErrorMessage = "Минимальная длина должна быть больше 30 символов")]
        public string Content { get; set; }

        public string Topic { get; set; }

        public string UserName { get; set; }
    }
}
