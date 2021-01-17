using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ComedySite.NewsApi
{
	/// <summary>
	/// Exposes methods to return NewsAPI data
	/// </summary>
	public class NewsApiService
	{
		public HttpClient Client { get; }

		public NewsApiService(HttpClient client)
		{
			client.BaseAddress = new Uri("http://newsapi.org/v2/everything?q=Trump");
			// GitHub API versioning
			client.DefaultRequestHeaders.Add("x-api-key","<TODO:use config file>");

			Client = client;
		}

		public async Task<NewsResult> GetLastNews()
		{
			var response = await Client.GetAsync("");

			response.EnsureSuccessStatusCode();

			// using var responseStream = await response.Content.ReadAsStreamAsync();

			// return await JsonSerializer.DeserializeAsync
			// 	<IEnumerable<NewsResult>>(responseStream);

			var test = await response.Content.ReadAsStringAsync();

			Console.WriteLine(value: $"risultato: {test}");

			var myJsonResponse = await response.Content.ReadAsStreamAsync();

			return await JsonSerializer.DeserializeAsync<NewsResult>(myJsonResponse);
		}
	}
}