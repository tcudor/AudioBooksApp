using AudioBooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace AudioBooksApp.Data.ViewModels
{
    public class NewBookDropdownsVM
    {

        public NewBookDropdownsVM()
        {
            Readers = new List<Reader>();
            Authors = new List<Author>();
            Publishers = new List<Publisher>();
        }

        public List<Reader> Readers { get; set; }
        public List<Publisher> Publishers { get; set; }
        public List<Author> Authors { get; set; }
    }
}