using AvoidsCommunication.DAL.Interfaces;
using AvoidsCommunication.Domain.Entity;
using AvoidsCommunication.Domain.Enum;
using AvoidsCommunication.Domain.Response;
using AvoidsCommunication.Domain.ViewModel.Rambling;
using AvoidsCommunication.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AvoidsCommunication.Service.Implementations
{
    public class RamblingService : IRamblingService
    {

        private readonly IBaseRepository<Rambling> _ramblingRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly ILogger<UserService> _logger;

        public RamblingService(IBaseRepository<Rambling> ramblingRepository,
            ILogger<UserService> logger, IBaseRepository<User> userRepository)
        {
            _ramblingRepository = ramblingRepository;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<IBaseResponse<Rambling>> Create(RamblingViewModel model, byte[] imageData, string username)
        {
            var user = _userRepository.GetAll().Where(x => x.Name == username).First();
            try
            {  
                var rambling = new Rambling()
                {
                    Name = model.Name,
                    Content = model.Content,
                    Topic = (Topic)Convert.ToInt32(model.Topic),
                    Cover = imageData,
                    User = user,
                    CreatedDate = DateTime.Now,
                };
                await _ramblingRepository.Create(rambling);

                return new BaseResponse<Rambling>()
                {
                    StatusCode = StatusCode.OK,
                    Data = rambling
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Rambling>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Rambling>> Edit(int id, RamblingViewModel model)
        {
            try
            {
                var rambling = await _ramblingRepository.GetAll().FirstOrDefaultAsync(x => x.RamblingId == id);
                if (rambling == null)
                {
                    return new BaseResponse<Rambling>()
                    {
                        Description = "Rambling not found",
                        StatusCode = StatusCode.RamblingNotFound
                    };
                }

                rambling.CreatedDate = model.CreatedDate;
                rambling.Content = model.Content;
                rambling.Cover = model.Cover;
                rambling.Name = model.Name;
                rambling.Topic = (Topic)Convert.ToInt32(model.Topic);

                await _ramblingRepository.Update(rambling);


                return new BaseResponse<Rambling>()
                {
                    Data = rambling,
                    StatusCode = StatusCode.OK,
                };
  
            }
            catch (Exception ex)
            {
                return new BaseResponse<Rambling>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<RamblingViewModel>> GetRambling(int id)
        {
            try
            {
                var rambling = await _ramblingRepository.GetAll().FirstOrDefaultAsync(x => x.RamblingId == id);
                if (rambling == null)
                {
                    return new BaseResponse<RamblingViewModel>()
                    {
                        Description = "Статья не найдена",
                        StatusCode = StatusCode.RamblingNotFound
                    };
                }

                var data = new RamblingViewModel()
                {
                    RamblingId = rambling.RamblingId,
                    Name = rambling.Name,
                    CreatedDate = rambling.CreatedDate,
                    Cover = rambling.Cover,
                    Content = rambling.Content,
                    Topic = rambling.Topic.ToString(),
                    UserName = rambling.User.Name,
                    Comments = rambling.Comments
                };

                return new BaseResponse<RamblingViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<RamblingViewModel>()
                {
                    Description = $"[GetRambling] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<Rambling>> GetRamblings()
        {
            try
            {
                var ramblings = _ramblingRepository.GetAll().ToList();
                if (!ramblings.Any())
                {
                    return new BaseResponse<List<Rambling>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Rambling>>()
                {
                    Data = ramblings,
                    StatusCode = StatusCode.OK
                };
            }

        catch (Exception ex)
            {
                return new BaseResponse<List<Rambling>>()
                {
                    Description = $"[GetRamblings] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
