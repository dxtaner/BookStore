using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public CreateGenreCommand(BookStoreDbContext context)
        {
            _dbContext = context;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(g =>g.name == Model.name);
    
            if(genre is not null) 
                throw new InvalidOperationException("Kitaba Ait Tip Mevcut");

            genre = new Genre();
            genre.name = Model.name;
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string name { get; set; }
    }
}
