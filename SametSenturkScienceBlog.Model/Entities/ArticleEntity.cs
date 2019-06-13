using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SametSenturkScienceBlog.Model.Entities
{
    public class ArticleEntity
    {
        public ArticleEntity(int? id, string title, DateTime addDate, int categoryId, string description, string fullContent, int seeCount)
        {
            this.Id = id;
            this.Title = title;
            this.AddDate = AddDate;
            this.CategoryID = categoryId;
            this.Description = description;
            this.FullContent = fullContent;
            this.SeeCount = seeCount;
        }

        public ArticleEntity()
        {

        }

        public int? Id { get; set; }

        public string Title { get; set; }

        public DateTime AddDate { get; set; }

        public int CategoryID { get; set; }

        public string Description { get; set; }

        public string FullContent { get; set; }

        public int SeeCount { get; set; }

        public ArticleCategoryEntity Category { get; set; }
    }
}
