using AvoidsCommunication.Domain.Entity;
using AvoidsCommunication.Domain.Response;
using AvoidsCommunication.Domain.ViewModel.Rambling;

namespace AvoidsCommunication.Service.Interfaces
{
    public interface IRamblingService
    {
        IBaseResponse<List<Rambling>> GetRamblings();
        Task<IBaseResponse<RamblingViewModel>> GetRambling(int id);
        Task<IBaseResponse<Rambling>> Create(RamblingViewModel model, byte[]? imageData, string username);
    }
}
