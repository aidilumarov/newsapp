using NewsApp.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewsApp.Services
{
    public class NewsService
    {
        public async Task<NewsResult> GetNewsAsync(NewsScope scope)
        {
            string url = GetUrl(scope);

            var webclient = new WebClient();
            var json = await webclient.DownloadStringTaskAsync(url);

            return JsonConvert.DeserializeObject<NewsResult>(json);
        }

        private string GetUrl(NewsScope scope)
        {
            return scope switch
            {
                NewsScope.Headlines => Headlines,
                NewsScope.Local => Local,
                NewsScope.Global => Global,
                _ => throw new Exception("Undefined scope")
            };
        }

        private string Headlines =>
            "https://newsapi.org/v2/top-headlines?" +
            "country=us&" + $"apiKey={Settings.NewsApiKey}";

        private string Local =>
            "https://newsapi.org/v2/everything?q=local&" +
            $"apiKey={Settings.NewsApiKey}";

        private string Global =>
            "https://newsapi.org/v2/everything?q=global&" +
            $"apiKey={Settings.NewsApiKey}";
    }
}
