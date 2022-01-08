using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstCourse.Model
{
    public class StringHelper
    {
        public static string GetCanonicalForm(string str) 
        {
            if (str == null) throw new ArgumentException("worng string");

            return str.Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.ToUpper())
                .OrderBy(s => s)
                .Aggregate("",(x, y) => x + " " + y)
                .Trim();
        }
    }
}
