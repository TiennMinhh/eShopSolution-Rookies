using Refit;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IIdentityProviderService
    {
        [Get("/hello/{yourName}")]
        Task<string> SayHello(string yourName);
    }
}
