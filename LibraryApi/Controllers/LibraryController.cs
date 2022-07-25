//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;

//namespace LibraryApi.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class LibraryController : ControllerBase
//    {
//        private readonly LibraryContext _db;
//        public LibraryController(LibraryContext context)
//        {
//            _db = context;
//        }
//        // https:localhost:55322/api/personal

//        [HttpPost] // create
//        public IActionResult CreateBook(Book book)
//        {
//            _db.Books.Add(book);
//            _db.SaveChanges();
//            return CreatedAtAction("GetBook", new { id = book.Id }, book);
//        }
//        [HttpGet]
//        public IActionResult GetBook(int id)
//        {
//            Book bookFromDb = _db.Books.SingleOrDefault(b => b.Id == id);
//            if(bookFromDb== null)
//            {
//                return NotFound();
//            }
//            return Ok(bookFromDb);
//        }
//        [HttpPut]
//        public IActionResult UpdateBook(Book book)
//        {
//            Book bookFromDb = _db.Books.SingleOrDefault(b => b.Id == book.Id);
//            if(bookFromDb == null)
//            {
//                return NotFound();
//            }
//            bookFromDb.Title = book.Title;
//            bookFromDb.PageCount = book.PageCount;
//            _db.SaveChanges();
//            return Ok("Updated book successfully");
//        }
//        [HttpDelete]
//        public IActionResult DeleteBook(int id)
//        {
//            Book bookFromDb = _db.Books.SingleOrDefault(b => b.Id == id);
//            if(bookFromDb == null)
//            {
//                return NotFound();
//            }
//            _db.Remove(bookFromDb);
//            _db.SaveChanges();
//            return Ok("Deleted Book");
//        }
//    }
//}
