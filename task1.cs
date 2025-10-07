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
        Console.Write("\nEnter number of characters per file: ");
        int charsPerFile = int.Parse(Console.ReadLine());

        int totalFiles = (paragraph.Length + charsPerFile - 1) / charsPerFile;
        int digits = totalFiles < 10 ? 1 : (totalFiles < 100 ? 2 : 3);
        for (int i = 0; i < 1000; i++) 
        {
            string fileName = i < 9 ? $"0{i + 1}.txt" :
                              i < 99 ? $"{(i + 1).ToString("D2")}.txt" :
                              $"{(i + 1).ToString("D3")}.txt";
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        for (int i = 0; i < totalFiles; i++)
        {
            int startIndex = i * charsPerFile;
            int length = Math.Min(charsPerFile, paragraph.Length - startIndex);
            string chunk = paragraph.Substring(startIndex, length);

            string fileName = digits == 3 ? $"{(i + 1).ToString("D3")}.txt" :
                              digits == 2 ? $"{(i + 1).ToString("D2")}.txt" :
                              $"{i + 1}.txt";

            File.WriteAllText(fileName, chunk);
        }

        Console.WriteLine($"\nParagraph split into {totalFiles} files successfully!");

        
        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1 - View a split file");
            Console.WriteLine("2 - Combine all split files into output.txt");
            Console.WriteLine("3 - Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write($"Enter file number (1 to {totalFiles}): ");
                int fileNum = int.Parse(Console.ReadLine());
                if (fileNum >= 1 && fileNum <= totalFiles)
                {
                    string fileName = digits == 3 ? $"{fileNum.ToString("D3")}.txt" :
                                      digits == 2 ? $"{fileNum.ToString("D2")}.txt" :
                                      $"{fileNum}.txt";

                    string content = File.ReadAllText(fileName);
                    Console.WriteLine($"\n--- Content of {fileName} ---");
                    Console.WriteLine(content);
                    Console.WriteLine("--- End of file ---");
                }
                else
                {
                    Console.WriteLine("Invalid file number!");
                }
            }
            else if (choice == "2")
            {
                string combinedText = "";
                for (int i = 0; i < totalFiles; i++)
                {
                    string fileName = digits == 3 ? $"{(i + 1).ToString("D3")}.txt" :
                                      digits == 2 ? $"{(i + 1).ToString("D2")}.txt" :
                                      $"{i + 1}.txt";

                    combinedText += File.ReadAllText(fileName);
                }

                string outputFile = "output.txt";
                File.WriteAllText(outputFile, combinedText);
                Console.WriteLine($"\nAll split files combined into '{outputFile}' successfully!");
            }
            else if (choice == "3")
            {
                Console.WriteLine("Exiting program...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice! Try again.");
            }
        }
    }
}