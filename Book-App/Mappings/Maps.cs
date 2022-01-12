using AutoMapper;
using Book_App.Data;
using Book_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_App.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Book, BookVM>().ReverseMap();
        }
    }
}
