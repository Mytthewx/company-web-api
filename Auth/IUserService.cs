using System.Threading.Tasks;

namespace WebAPI
{
	public interface IUserService
	{
		Task<bool> Authenticate(string username, string password);
	}
}
