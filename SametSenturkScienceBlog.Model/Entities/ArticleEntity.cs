using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [MaxLength(50, ErrorMessage = "Invalid length for Title."), Required(ErrorMessage = "Title is required."), DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "AddDate is required."),DataType(DataType.DateTime)]
        public DateTime AddDate { get; set; }

        [Required(ErrorMessage = "CategoryID is required."),Range(1,int.MaxValue,ErrorMessage = "Invalid range for CatetgoryID")]
        public int CategoryID { get; set; }

        [MaxLength(150,ErrorMessage = "Invalid length for Description."),Required(ErrorMessage = "Description is required."),DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "FullContent is required."),DataType(DataType.MultilineText)]
        public string FullContent { get; set; }
        
        public int SeeCount { get; set; }

        public ArticleCategoryEntity Category { get; set; }
    }
}
