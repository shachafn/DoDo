using System;
using System.IO;

namespace DoDoHashCode
{
    class Program
    {
        static Data _data;
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\Users\97250\Desktop\google_hc\1.txt");
            _data = new Data(lines);

        }
    }
}
