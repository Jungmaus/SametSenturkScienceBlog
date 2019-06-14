using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SametSenturkScienceBlog.Model.Entities
{
    public class ArticleTagMappingEntity
    {
        public ArticleTagMappingEntity(int? id, int articleId, int tagId)
        {
            this.Id = id;
            this.ArticleId = articleId;
            this.TagId = tagId;
        }

        public ArticleTagMappingEntity()
        {

        }

        public int? Id { get; set; }
        [Required(ErrorMessage = "ArticleID is required."), Range(1, int.MaxValue, ErrorMessage = "Invalid range for ArticleID.")]
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "TagId is required."), Range(1, int.MaxValue, ErrorMessage = "Invalid range for TagId.")]
        public int TagId { get; set; }

        public ArticleEntity Article { get; set; }

        public TagEntity Tag { get; set; }
    }
}
