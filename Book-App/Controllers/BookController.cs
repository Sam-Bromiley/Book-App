using AutoMapper;
using Book_App.Contracts;
using Book_App.Data;
using Book_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_App.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: BookController
        public ActionResult Index()
        {
            
            var books =  _unitOfWork.Books.FindAll(
                includes: x => x.Include(y => y.Tags)
                .Include(z => z.TagAllocations), 
                orderBy: q => q.OrderByDescending(x => x.IsFavourite))
                .Result;
            //includes: new List<string> { "Tags", "TagAllocations" })
            var model = _mapper.Map<List<Book>, List<BookVM>>((List<Book>)books);
            return View(model);
        }

        // GET: BookController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _unitOfWork.Books.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var book = await _unitOfWork.Books.Find(
                expression: q => q.Id == id, 
                includes: x => x.Include(y => y.Tags)
                .Include(z => z.TagAllocations)); 
                //includes: new List<string> { "Tags", "TagAllocations" });
            var model = _mapper.Map<BookVM>(book);
            return View(model);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Book model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(model);
                }
                var book = _mapper.Map<Book>(model);
                book.DateAdded = DateTime.Now;
                await _unitOfWork.Books.Create(book);
                await _unitOfWork.Save();

                //if(isSuccess)
                //{
                //    ModelState.AddModelError("", "Something went wrong when adding your book");
                //    return View(model);
                //}

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.Books.isExists(q => q.Id == id);
            if(!isExists)
            {
                return NotFound();
            }
            var book = await _unitOfWork.Books.Find(expression: q => q.Id == id,
                includes: x => x.Include(y => y.Tags)
                .Include(z => z.TagAllocations));

            //new List<string>{ "Tags", "TagAllocations"}
            
      
            
            var model = _mapper.Map<BookVM>(book);
            return View(model);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BookVM model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(model);
                }
                var book = await _unitOfWork.Books.Find(expression: q => q.Id == id,
               includes: x => x.Include(y => y.Tags)
               .Include(z => z.TagAllocations));

                _unitOfWork.Books.Update(book);
                await _unitOfWork.Save();
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong updating this record");
                return View(model);
            }
        }

        // GET: BookController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var book = await _unitOfWork.Books.Find(expression: q => q.Id == id);
                if(book == null)
                {
                    return NotFound();
                }
                _unitOfWork.Books.Delete(book);
               await  _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
