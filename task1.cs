using System;
using System.IO;

class WriteParagraphToFile
{
    static void Main()
    {
        Console.WriteLine("Enter your paragraph (press ENTER twice to finish):");

        string line;
        string paragraph = "";
        while (true)
        {
            line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
                break; 
            paragraph += line + Environment.NewLine;
        }

        
        string filePath = "input.txt";

        File.WriteAllText(filePath, paragraph);

        Console.WriteLine($"\nParagraph saved successfully in '{filePath}'");
    }
}
