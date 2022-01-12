using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_App.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Link { get; set; }
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsFavourite { get; set; }
        public Tags Tags { get; set; }
        public TagAllocation TagAllocations { get; set; }


    }
}
