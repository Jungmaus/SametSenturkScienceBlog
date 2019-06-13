using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SametSenturkScienceBlog.Model.Entities
{
    public class ArticleTagMappingEntity
    {
        public ArticleTagMappingEntity(int? id, int articleId,int tagId)
        {
            this.Id = id;
            this.ArticleId = articleId;
            this.TagId = tagId;
        }

        public ArticleTagMappingEntity()
        {

        }

        public int? Id { get; set; }
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        public ArticleEntity Article { get; set; }

        public TagEntity Tag { get; set; }
    }
}
