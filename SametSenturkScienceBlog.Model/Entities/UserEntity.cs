using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SametSenturkScienceBlog.Model.Entities
{
    public class UserEntity
    {
        public UserEntity(int? id,string username, string password, DateTime? lastLogin)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.LastLogin = lastLogin;
        }

        public UserEntity()
        {

        }

        public int? Id { get; set; }

        [MaxLength(50, ErrorMessage = "Invalid length for Username."), Required(ErrorMessage = "Username is required."), DataType(DataType.Text)]
        public string Username { get; set; }

        [MaxLength(50, ErrorMessage = "Invalid length for Password."), Required(ErrorMessage = "Password is required."), DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastLogin { get; set; }

    }
}
