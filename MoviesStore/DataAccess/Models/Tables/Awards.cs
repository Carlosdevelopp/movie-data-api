using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Tables
{
    public class Awards
    {
        public int AwardId { get; set; }
        public string AwardTitle { get; set; }
        public virtual ICollection<Movies> Movies {  get; set; }
    }
}
