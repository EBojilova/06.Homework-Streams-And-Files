using System;
using System.IO;

class LineNumbers
{
    static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("../../LineNumbers.cs");
        StreamWriter writer = new StreamWriter("../../copy.cs");
        //StreamWriter writer = new StreamWriter("../../copy.cs", true);- ako iskame da appendvame kam veche sastestvuvash
        //StreamWriter writer = new StreamWriter("../../copy.cs", false);- zatriva sastestvuastia i pishe nov, taka e pod defolt
        using (reader)
        {
            using (writer)
            {
                int lineNumber = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    Console.WriteLine("Line {0}: {1}", lineNumber, line);
                    writer.WriteLine(line);
                }
            }
        }
    }
}
