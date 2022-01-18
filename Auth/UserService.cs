using System.Threading.Tasks;

namespace WebAPI
{
	public class UserService : IUserService
	{
		private const string USERNAME = "PumoxUser";
		private const string PASSWORD = "PumoxPassword";

		public Task<bool> Authenticate(string username, string password)
		{
			if (username == USERNAME && password == PASSWORD)
			{
				return Task.FromResult(true);
			}
			return Task.FromResult(false);
		}
	}
}
