using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SametSenturkScienceBlog.Model.Entities
{
    public class ArticleCommentEntity
    {
        public ArticleCommentEntity(int? id, string name, string email, string fullContent, int articleId, string ipAdress, bool isNotificationEnabled)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.FullContent = fullContent;
            this.ArticleID = articleId;
            this.IpAdress = ipAdress;
            this.IsNotificationEnabled = isNotificationEnabled;
        }

        public ArticleCommentEntity()
        {

        }

        public int? Id { get; set; }

        [MaxLength(50, ErrorMessage = "Invalid length for Name."), Required(ErrorMessage = "Name is required."), DataType(DataType.Text)]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "Invalid length for Email."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(350, ErrorMessage = "Invalid length for FullContent."), Required(ErrorMessage = "FullContent is required."), DataType(DataType.MultilineText)]
        public string FullContent { get; set; }

        [Required(ErrorMessage = "ArticleID is required.")]
        public int ArticleID { get; set; }

        [MaxLength(50, ErrorMessage = "Invalid length for IpAdress."), Required(ErrorMessage = "IpAdress is required."), DataType(DataType.Text)]
        public string IpAdress { get; set; }
        public bool IsNotificationEnabled { get; set; } = false;

        public ArticleEntity Article { get; set; }
    }
}
