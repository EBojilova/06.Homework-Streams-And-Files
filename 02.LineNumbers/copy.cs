Line 1: using System;
Line 2: using System.IO;
Line 3: 
Line 4: class LineNumbers
Line 5: {
Line 6:     static void Main(string[] args)
Line 7:     {
Line 8:         StreamReader reader = new StreamReader("../../LineNumbers.cs");
Line 9:         StreamWriter writer = new StreamWriter("../../copy.cs");
Line 10:         //StreamWriter writer = new StreamWriter("../../copy.cs", true);- ako iskame da appendvame kam veche sastestvuvash
Line 11:         //StreamWriter writer = new StreamWriter("../../copy.cs", false);- zatriva sastestvuastia i pishe nov, taka e pod defolt
Line 12:         using (reader)
Line 13:         {
Line 14:             using (writer)
Line 15:             {
Line 16:                 int lineNumber = 0;
Line 17:                 string line;
Line 18:                 while ((line = reader.ReadLine()) != null)
Line 19:                 {
Line 20:                     lineNumber++;
Line 21:                     string writeLine=string.Format("Line {0}: {1}", lineNumber, line);
Line 22:                     writer.WriteLine(writeLine);
Line 23:                 }
Line 24:             }
Line 25:         }
Line 26:     }
Line 27: }
