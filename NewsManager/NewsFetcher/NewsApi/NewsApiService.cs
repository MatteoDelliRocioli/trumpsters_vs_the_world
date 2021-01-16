using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NewsManager.NewsFetcher.NewsApi
{
	/// <summary>
	/// Exposes methods to return news from NewsAPI
	/// </summary>

	public class NewsApiService
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration Configuration;

		public NewsApiService(HttpClient client, IConfiguration configuration)
		{
			Configuration = configuration;

			const string apiKeyHeader = "x-api-key";

			client.BaseAddress = new Uri("http://newsapi.org/v2/everything");

			client.DefaultRequestHeaders.Add(apiKeyHeader, Configuration["newsApi:x-api-key"]);

		}
	}
}