
using System.Collections.Generic;
using Users.Data.Entities.Enums;

namespace Users.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int SortOder { get; set; }
        public bool IsShowOnHome { get; set; }
        public int? ParentID { get; set; }
        public Status Status { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
