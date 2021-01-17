using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ComedySite.NewsApi;

namespace ComedySite.Controllers
{
	public class LastNewsController : Controller
	{

		private readonly NewsApiService _newsApiService;
		public NewsResult NewsResults { get; private set; }
		public bool GetResultsError { get; private set; }

		//public bool hasResults => NewsResults.Any();

		public LastNewsController(NewsApiService newsApiService)
		{
			_newsApiService = newsApiService;
		}

		public async Task<IActionResult> LastNews()
		{
			try
			{
				NewsResults = await _newsApiService.GetLastNews();
				return View(NewsResults);
			}
			catch(HttpRequestException)
			{
				GetResultsError = true;
				//NewsResults = Array.Empty<NewsResult>();
				//NewsResults = null;
				return View();
			}

		}

	}
}
