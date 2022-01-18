using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace WebAPI
{
	public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
	{
		private readonly IUserService _userService;

		public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, 
			ILoggerFactory logger, 
			UrlEncoder encoder, 
			ISystemClock clock,
			IUserService userService) 
			: base(options, logger, encoder, clock)
		{
			_userService = userService;
		}

		protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			if (!Request.Headers.ContainsKey("Authorization"))
			{
				return AuthenticateResult.Fail("Authorization header was not found.");
			}

			string username;
			bool result;

			try
			{
				var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
				var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
				var credentials = Encoding.UTF8.GetString(bytes).Split(":");
				username = credentials[0];
				string password = credentials[1];
				result = await _userService.Authenticate(username, password);
			}
			catch
			{
				return AuthenticateResult.Fail("Invalid Username or Password");
			}


			var claims = new[] {
				new Claim(ClaimTypes.Name, username)
			};
			var identity = new ClaimsIdentity(claims, Scheme.Name);
			var principal = new ClaimsPrincipal(identity);
			var ticket = new AuthenticationTicket(principal, Scheme.Name);

			if (result)
			{
				return AuthenticateResult.Success(ticket);
			}

			return AuthenticateResult.Fail("Invalid Username or Password");
		}
	}
}
