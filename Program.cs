using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace WebAPI
{
	class Program
	{
		static void Main(string[] args)
		{
			BuildWebHost(args).Run();
			Console.WriteLine("Please enter any key to exit.");
			Console.ReadLine();
		}

		public static IWebHost BuildWebHost(string[] args) =>
		   WebHost.CreateDefaultBuilder(args).UseUrls("http://localhost:8080")
				  .UseStartup<Startup>()
				  .Build();
	}
}
