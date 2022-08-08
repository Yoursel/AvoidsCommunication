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
        private readonly ILogger<UserService> _logger;

        public RamblingService(IBaseRepository<Rambling> ramblingRepository,
            ILogger<UserService> logger)
        {
            _ramblingRepository = ramblingRepository;
            _logger = logger;
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
                    Name = rambling.Name,
                    CreatedDate = rambling.CreatedDate,
                    Cover = rambling.Cover,
                    Content = rambling.Content,
                    Topic = rambling.Topic.ToString(),
                    UserName = rambling.User.Name
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
