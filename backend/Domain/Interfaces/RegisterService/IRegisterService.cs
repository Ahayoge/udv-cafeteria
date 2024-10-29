using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.RegisterService
{
    public interface IRegisterService
    {
        public Task<ValueResult<string>> RegisterAsync(User user, string password);
    }
}
