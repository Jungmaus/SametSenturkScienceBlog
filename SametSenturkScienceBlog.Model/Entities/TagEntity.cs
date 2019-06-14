using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SametSenturkScienceBlog.Model.Entities
{
    public class TagEntity
    {
        public TagEntity(int? id,string name,string seoName)
        {
            this.Id = id;
            this.Name = name;
            this.SeoName = seoName;
        }

        public int? Id { get; set; }

        [MaxLength(50,ErrorMessage = "Invalid length for Name."),Required(ErrorMessage = "Name is required."),DataType(DataType.Text)]
        public string Name { get; set; }

        [MaxLength(55, ErrorMessage = "Invalid length for SeoName."), Required(ErrorMessage = "SeoName is required."), DataType(DataType.Text)]
        public string SeoName { get; set; }
    }
}
