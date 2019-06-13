using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SametSenturkScienceBlog.Model.Entities
{
    public class ArticleCommentEntity
    {
        public ArticleCommentEntity(int? id, string name,string email,string fullContent,int articleId, string ipAdress,bool isNotificationEnabled)
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
        public string Name { get; set; }
        public string Email { get; set; }
        public string FullContent { get; set; }
        public int ArticleID { get; set; }
        public string IpAdress { get; set; }
        public bool IsNotificationEnabled { get; set; }

        public ArticleEntity Article { get; set; }
    }
}
