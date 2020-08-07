using System;

namespace ResourceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "a";

            while (true)
            {
                str += str;
                Console.WriteLine("Length string " + str.Length);
            }
        }
    }
}
