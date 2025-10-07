using System;

namespace view.views
{
    class FragmentationView
    {
        public string GetParagraph()
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
            return paragraph;
        }

        public int GetCharsPerFile()
        {
            Console.Write("\nEnter number of characters per file: ");
            return int.Parse(Console.ReadLine());
        }

        public int ShowMenu()
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1 - View a split file");
            Console.WriteLine("2 - Combine all split files into output.txt");
            Console.WriteLine("3 - Exit");
            Console.Write("Enter your choice: ");
            return int.Parse(Console.ReadLine());
        }

        public int AskFileNumber(int totalFiles)
        {
            Console.Write($"Enter file number (1 to {totalFiles}): ");
            return int.Parse(Console.ReadLine());
        }

        public void DisplayFile(string fileName, string content)
        {
            Console.WriteLine($"\n--- {fileName} ---");
            Console.WriteLine(content);
            Console.WriteLine("--- End of file ---");
        }

        public void DisplayMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
