using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Aplication.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.userEmail == Model.userEmail);
            if (user != null)
                throw new InvalidOperationException("Kullanıcı zaten mevcut");

            user = _mapper.Map<User>(Model);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        public class CreateUserModel
        {

            public string userName { get; set; }
            public string userSurName { get; set; }
            public string userEmail { get; set; }
            public string userPassword { get; set; }
        }
    }
}