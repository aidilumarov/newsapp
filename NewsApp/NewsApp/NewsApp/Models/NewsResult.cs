using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Models
{
    public class NewsResult
    {
        public string Status { get; set; }

        public int TotalResults { get; set; }

        public List<Article> Articles { get; set; }
    }
}
