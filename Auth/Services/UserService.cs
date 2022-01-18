using System.Threading.Tasks;

namespace WebAPI
{
	public class UserService : IUserService
	{
		private const string USERNAME = "PumoxUser";
		private const string PASSWORD = "PumoxPassword";

		public Task<bool> Authenticate(string username, string password)
		{
			return Task.FromResult(username == USERNAME && password == PASSWORD);
		}
	}
}
