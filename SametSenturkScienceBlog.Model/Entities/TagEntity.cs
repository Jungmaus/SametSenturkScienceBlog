using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string SeoName { get; set; }
    }
}
