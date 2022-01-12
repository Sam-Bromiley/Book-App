using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_App.Data
{
    public class TagAllocation
    {
        public int Id { get; set; }
        [ForeignKey("BookId")]
        public Book Books { get; set; }
        public int BookId { get; set; }
        [ForeignKey("TagId")]
        public Tags Tag { get; set; }
        public int TagId { get; set; }
    }
}
