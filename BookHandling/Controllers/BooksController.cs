using BookHandling.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHandling.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Search(string SearchId)
        {
            Book book = Book.GetByName(SearchId);
            if (book == null) 
            {
                return View("BookNotFound");
            }
            return View("Details",book);
        }
        // GET: BooksController
        public ActionResult Index()
        {
            return View(Book.GetAllBooks());
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Book book = Book.GetBookById(id);
                return View(book);
            }
            catch
            {
                return NotFound();
            }
            
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                Book.Create(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Book.GetBookById(id));
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                Book.Update(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Book.GetBookById(id));
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Book.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
