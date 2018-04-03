using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkeshPatelFullStackLib.model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryKeyword { get; set; }
    }
}
