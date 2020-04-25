using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
  public class BlogComment:Base
    {

        public int BlogId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

    }
}
