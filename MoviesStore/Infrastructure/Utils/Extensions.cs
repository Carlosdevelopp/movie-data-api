using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public static class Extensions
    {
        public static string FormatTitle(this string txt)
        {
            if (txt == null) throw new ArgumentNullException(nameof(txt));
            return $"*{txt}*";
        }
    }
}
