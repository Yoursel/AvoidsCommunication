using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidsCommunication.Domain.ViewModel.Comment
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public int RamblingId { get; set; }

        [Required(ErrorMessage = "Введите комментарий")]
        public string CommentText { get; set; }
    }
}
