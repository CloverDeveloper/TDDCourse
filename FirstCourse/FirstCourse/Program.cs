using System;
using FirstCourse.Model;

namespace FirstCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            var empty = StringHelper.GetCanonicalForm(" ");
            Console.WriteLine(empty == "");

            empty = StringHelper.GetCanonicalForm("     ");
            Console.WriteLine(empty == "");

            empty = StringHelper.GetCanonicalForm("          ");
            Console.WriteLine(empty == "");

            Console.WriteLine(StringHelper.GetCanonicalForm("  Hello    World!"));
            Console.WriteLine(StringHelper.GetCanonicalForm("     Hello       World!   "));
            Console.WriteLine(StringHelper.GetCanonicalForm("Hello World!"));
            Console.WriteLine(StringHelper.GetCanonicalForm("World! Hello"));
        }
    }
}
