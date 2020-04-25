using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.Model
{
   public class AdvertPhoto : Base
    {
        [ForeignKey("Adverts")]
        public int AdvertId { get; set; }
        [Required]
        public string Photo { get; set; }
        public virtual Advert Adverts { get; set; }
    }
}
