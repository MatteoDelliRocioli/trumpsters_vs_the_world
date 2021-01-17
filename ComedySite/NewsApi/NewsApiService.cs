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
			Client = client;
		}

		public async Task<NewsResult> GetLastNews()
		{
			var response = await Client.GetAsync("");

			response.EnsureSuccessStatusCode();

			var myJsonResponse = await response.Content.ReadAsStreamAsync();

			return await JsonSerializer.DeserializeAsync<NewsResult>(myJsonResponse);
		}

		public void SetClientBaseAddress(string baseAddress)
		{
			Client.BaseAddress = new Uri(baseAddress);
		}
		public void SetRequestHeaders(Dictionary<string, string> headers)
		{
			foreach (var header in headers)
			{
				Client.DefaultRequestHeaders.Add(header.Key, header.Value);
			}
		}
	}
}