namespace Infrastructure.Utils
{
    public static class Extensions
    {
        public static string FormatTitle(this string txt)
        {
            if (txt == null) throw new ArgumentNullException(nameof(txt));
            return $"*{txt}*";
        }
        public static string ToUpper(this string txt)
        {
            if(txt == null) throw new ArgumentNullException(nameof(txt));
            return txt.ToUpper();   
        }
        public static string ShortDate(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
        public static string FormatTime(this int txt)
        {
                return string.Format($"#{txt}");
        }
    }
}
