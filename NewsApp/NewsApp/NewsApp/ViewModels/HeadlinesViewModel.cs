using NewsApp.Models;
using NewsApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class HeadlinesViewModel : BaseViewModel
    {
        #region Fields

        private readonly NewsService newsService;

        #endregion

        #region Properties
        
        public NewsResult CurrentNews { get; set; }

        #endregion

        #region Constructors

        public HeadlinesViewModel(NewsService newsService)
        {
            this.newsService = newsService;
        }

        #endregion

        #region PublicMethods

        public async Task Initialize(string scope)
        {
            var resolvedScope = scope.ToLower() switch
            {
                "local" => NewsScope.Local,
                "global" => NewsScope.Global,
                "headlines" => NewsScope.Headlines,
                _ => NewsScope.Headlines
            };

            await Initialize(resolvedScope);
        }

        public async Task Initialize(NewsScope scope)
        {
            CurrentNews = await newsService.GetNewsAsync(scope);
            Console.WriteLine();
        }

        #endregion

        #region Commands

        public ICommand ItemSelected =>
            new Command(async (selectedItem) =>
            {
                var selectedArticle = selectedItem as Article;
                var url = HttpUtility.UrlEncode(selectedArticle.Url);
                await Navigation.NavigateTo($"articleview?url={url}");
            });

        #endregion
    }
}
