using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using ComedySite.NewsApi;

namespace ComedySite.Controllers
{
	public class LastNewsController : Controller
	{
		public NewsResult NewsResults { get; private set; }

		public bool GetResultsError { get; private set; }

		private IConfiguration Configuration { get; set; }

		private readonly NewsApiService _newsApiService;

		public LastNewsController(NewsApiService newsApiService, IConfiguration configuration)
		{
			Configuration = configuration;
			_newsApiService = newsApiService;
		}

		public async Task<IActionResult> LastNews()
		{
			try
			{
				_newsApiService.SetClientBaseAddress(
					Configuration.GetValue<string>("newsApi:baseHost"));

				var apiKeyHeader = new Dictionary<string, string>
				{{
					"x-api-key",
					Configuration.GetValue<string>("newsApi:xApiKey")
				}};

				_newsApiService.SetRequestHeaders(apiKeyHeader);

				NewsResults = await _newsApiService.GetLastNews();

				return View(NewsResults);
			}
			catch(HttpRequestException he)
			{
				Console.WriteLine($"HttpRequestException: {he.Message}");

				GetResultsError = true;
				//NewsResults = Array.Empty<NewsResult>();
				//NewsResults = null;
				return View();
			}

		}

	}
}
