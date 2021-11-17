using System;
using System.Linq;

namespace SQL_Uppgift_1 
{
    static class Box
    {     
        public static void Simple(string[] rows)
        {
            string longestRow = rows.OrderByDescending(s => s.Length).First();

            Console.Write("┌");
            for (int i = 0; i < longestRow.Length; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("──┐");


            foreach (var line in rows)
            {
                Console.Write($"│ {line}");
                int spaces = longestRow.Length - line.Length;
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(" │");
            }

            Console.Write("└");
            for (int i = 0; i < longestRow.Length; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("──┘");
        }
        public static void Roof(int length)
        {
            Console.Write("┌");
            for (int i = 0; i < length - 2; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");
        }

        public static void Floor(int length)
        {
            Console.Write("└");
            for (int i = 0; i < length - 2; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┘");
        }

        static void WithDivider(string top, string[] mid, string bot) //currently not working and not in use. Will save for other projects
        {
            int roof = top.Length;


            //if (length == 0) length = text.Length;

            Console.Write("┌");
            for (int i = 0; i < top.Length; i++)
            {
                Console.Write("─");
                //if (top[i].ToString() == "│")
                //{
                //    Console.Write("┬");

                //    if (top[i + 1].ToString() == "│")
                //    {
                //        Console.Write("┬");
                //        i++;
                //    }
                //    i++;
                //}
            }
            Console.WriteLine("──┐");

            Console.WriteLine($"│ {top} │");


            foreach (var line in mid)
            {
                Console.Write($"│ {line}");
                int spaces = top.Length - line.Length;
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(" │");
            }


            Console.WriteLine($"│ {bot} │");

            Console.Write("└");
            for (int i = 0; i < top.Length; i++)
            {
                Console.Write("─");
                //if (mid[i].ToString() == "│")
                //{
                //    Console.Write("┴");
                //    if (mid[i + 1].ToString() == "│")
                //    {
                //        Console.Write("┴");
                //        i++;
                //    }
                //    i++;
                //}
            }
            Console.WriteLine("──┘");
        }
    }
}
