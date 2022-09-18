using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        public string userName { get; set; }
        public string userSurName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public string userRefreshToken { get; set; }
        public DateTime? userRefreshTokenExpireDate { get; set; }


    }
}