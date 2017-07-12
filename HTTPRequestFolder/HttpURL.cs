using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NavigationFromUnityToXamarin.HTTPRequestFolder
{
	public class HttpURL<TModel> where TModel : class
	{
		public async Task<List<TModel>> GetManyAsync(string requestUrl)
		{

			try
			{
				using (var client = new HttpClient())
				{
					//client.BaseAddress = new Uri(requestUri);

					var response = await client.GetAsync(requestUrl);

					response.EnsureSuccessStatusCode();

					return JsonConvert.DeserializeObject<List<TModel>>(await response.Content.ReadAsStringAsync());
				}
			}
			catch (Exception)
			{
				//Helpers.LoggingHelper.Log(e);
				return null;
			}
		}
	}
}
