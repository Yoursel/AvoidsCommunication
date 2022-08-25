using AvoidsCommunication.Domain.Entity;
using AvoidsCommunication.Domain.Response;
using AvoidsCommunication.Domain.ViewModel.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidsCommunication.Service.Interfaces
{
    public interface ICommentService
    {
        Task<IBaseResponse<Comment>> Create(CommentViewModel model, string username);

        Task<IBaseResponse<bool>> Delete(int id);

        Task<IBaseResponse<Comment>> Edit(int id, CommentViewModel model);
    }
}
