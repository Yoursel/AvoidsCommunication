using AvoidsCommunication.Domain.Entity;
using AvoidsCommunication.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidsCommunication.Service.Interfaces
{
    public interface IRamblingService
    {
        IBaseResponse<List<Rambling>> GetRamblings();
        Task<IBaseResponse<Rambling>> GetRambling(int id);

    }
}
