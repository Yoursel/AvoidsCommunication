using AvoidsCommunication.DAL.Interfaces;
using AvoidsCommunication.Domain.Entity;
using AvoidsCommunication.Domain.Enum;
using AvoidsCommunication.Domain.Response;
using AvoidsCommunication.Domain.ViewModel.Comment;
using AvoidsCommunication.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace AvoidsCommunication.Service.Implementations
{
    public class CommentService : ICommentService
    {

        private readonly IBaseRepository<Comment> _commentRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly ILogger<UserService> _logger;

        public CommentService(IBaseRepository<Comment> commentRepository,
            ILogger<UserService> logger, IBaseRepository<User> userRepository)
        {
            _commentRepository = commentRepository;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<IBaseResponse<Comment>> Create(CommentViewModel model, string username)
        {
            try
            {
                var user = _userRepository.GetAll().Where(x => x.Name == username).First();
                var comment = new Comment()
                {
                    CommentText = model.CommentText,
                    CreatedDate = DateTime.Now,
                    User = user,
                    RamblingId = model.RamblingId
                };

                await _commentRepository.Create(comment);

                return new BaseResponse<Comment>()
                {
                    StatusCode = StatusCode.OK,
                    Data = comment
                };
            }

            catch (Exception ex)
            {
                return new BaseResponse<Comment>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public Task<IBaseResponse<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Comment>> Edit(int id, CommentViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
