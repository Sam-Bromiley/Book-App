using Book_App.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_App.Models
{
    public class BookVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Title")]
        public string Name { get; set; }
        public string Author { get; set; }
        public string Link { get; set; }
        public string Text { get; set; }
        public DateTime? DateAdded { get; set; }
        [Display(Name = "Favourite")]
        public bool IsFavourite { get; set; }
        public Tags Tags { get; set; }
        public TagAllocation TagAllocations { get; set; }
    }
}
