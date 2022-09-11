using System;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.Commands.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext _context)
        {
            this._context = _context;
        }

        // private static List<Book> BookList = new List<Book>(){

        //  new Book()
        //     {
        //         Id = 1,
        //         title = "LOTR",
        //         genreId = 1,
        //         pageCount = 320,
        //         publishDate = new DateTime(2000, 12, 02)
        //     },
        //   new Book()
        //     {
        //         Id = 2,
        //         title = "Peri",
        //         genreId = 2,
        //         pageCount = 60,
        //         publishDate = new DateTime(2022, 08, 02)
        //     },
        //      new Book()
        //     {
        //         Id = 3,
        //         title = "Yüzüklerin Efendisi: Kralın Dönüşü (2003)",
        //         genreId = 1,
        //         pageCount = 201,
        //         publishDate = new DateTime(2003, 12, 19)
        //     },
        //     new Book()
        //     {
        //         Id = 4,
        //         title = "LowHigh",
        //         genreId = 3,
        //         pageCount = 550,
        //         publishDate = new DateTime(2016, 11, 12)
        //     },

        // };

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookDetailViewModel result;

            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result=query.Handle();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
            // return Ok(result);
            return Ok();
        }

        // [HttpGet]
        // public Book Get([FromQuery] string id)
        // {
        //     var book = Booklist.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);

            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }

        [HttpPut]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {

            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}