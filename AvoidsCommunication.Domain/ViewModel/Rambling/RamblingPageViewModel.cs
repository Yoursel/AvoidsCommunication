using AvoidsCommunication.Domain.Response;
using AvoidsCommunication.Domain.ViewModel.Comment;


namespace AvoidsCommunication.Domain.ViewModel.Rambling
{
    public class RamblingPageViewModel
    {
        public IBaseResponse<RamblingViewModel> Rambling { get; set; }
        public CommentViewModel Comment { get;set; }
    }
}
