using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class AwardsDTO
    {
        public string TitleMovie {  get; set; } 
        public string DescriptionMovie { get; set; }  
        public DateTime ReleaseMovie {  get; set; }
        public int RunningTime { get; set; }
        public int Genre {  get; set; }
        public int Award {  get; set; }
    }
}
