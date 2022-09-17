using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using FluentValidation;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Aplication.AuthorOperations.Queries.GetAuthorDetail;

namespace WebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //     GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            //     query.authorId = id;
            //     GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            //     validator.ValidateAndThrow(query);

            // //     var obj = query.Handle();
            // //     return Ok(obj);
            GetAuthorDetailViewModel result;

            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.authorId = id;
            result = query.Handle();
            // return Ok(result);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddAuthore([FromBody] CreateAuthorModel newAuthore)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context);
            command.Model = newAuthore;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

            
        [HttpPut]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.authorId = id;
            command.Model = updateAuthor;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthore(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

    }
}