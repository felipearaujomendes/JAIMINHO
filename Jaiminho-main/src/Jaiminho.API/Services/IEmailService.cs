using Jaiminho.API.ViewModels;
using System.Threading.Tasks;

namespace Jaiminho.API.Services
{
    public interface IEmailService
    {
        public Task<bool> SendMailAsync(EmailViewModel emailViewModel);
    }
}
