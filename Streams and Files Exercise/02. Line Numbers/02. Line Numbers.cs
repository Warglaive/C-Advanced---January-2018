using System.IO;

namespace _02._Line_Numbers
{
    public class Program
    {
        public static void Main()
        {
            using (var readStream = new StreamReader("text.txt"))
            {
                using (var writeStream = new StreamWriter("numberedText.txt"))
                {
                    var lineNumber = 1;
                    string line = readStream.ReadLine();
                    while (line != null)
                    {
                        writeStream.WriteLine($"Line {lineNumber}: {line}");
                        lineNumber++;
                        line = readStream.ReadLine();
                    }
                }
            }
        }
    }
}
