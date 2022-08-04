using AvoidsCommunication.DAL.Interfaces;
using AvoidsCommunication.Domain.Entity;
using AvoidsCommunication.Domain.Enum;
using AvoidsCommunication.Domain.Response;
using AvoidsCommunication.Service.Interfaces;
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
        public Task<IBaseResponse<Rambling>> GetRambling(int id)
        {
            throw new NotImplementedException();
        }

        public IBaseResponse<List<Rambling>> GetRamblings()
        {
            try
            {
                var cars = _ramblingRepository.GetAll().ToList();
                if (!cars.Any())
                {
                    return new BaseResponse<List<Rambling>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Rambling>>()
                {
                    Data = cars,
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
