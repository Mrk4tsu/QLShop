using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Data.Entities
{
    public class ProductTranslation
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LangueId { set; get; }

    }
}
