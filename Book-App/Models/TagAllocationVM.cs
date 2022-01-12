using Book_App.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_App.Models
{
    public class TagAllocationVM
    {
        public int Id { get; set; }
        public UserDetails User { get; set; }
        public string UserId { get; set; }
        public Tags Tag { get; set; }
        public int TagId { get; set; }
    }
}
