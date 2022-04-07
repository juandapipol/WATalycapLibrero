using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteWebApiLibrero.Models
{
    public class Books
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int pageCount { get; set; }
        public string excerpt { get; set; }
        public DateTime publishDate { get; set; }
    }
}