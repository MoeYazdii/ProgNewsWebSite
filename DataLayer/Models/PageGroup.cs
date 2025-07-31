using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroup
    {
        [Key]
        public int GroupID { get; set; }
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")] //{0} ==  Name=""
        [MaxLength(150)]

        public string GroupTitle { get; set; }



        //Relations
        public virtual List<NewsPage> NewsPages { get; set; }
        public PageGroup()
        {
        }
    }
}
