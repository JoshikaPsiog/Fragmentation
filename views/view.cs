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
            return paragraph.TrimEnd();

        }

        public int GetCharsPerFile()
        {
            int charsPerFile;
            while (true)
            {
                Console.Write("Enter number of characters per file: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out charsPerFile) && charsPerFile > 0)
                    break;
                Console.WriteLine("Invalid input! Please enter a positive number.");
            }
            return charsPerFile;
        }

        public int ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1 - View a split file");
                Console.WriteLine("2 - Combine all split files into output.txt");
                Console.WriteLine("3 - Delete all split files and exit");
                Console.WriteLine("4 - Compare input and output");
                Console.WriteLine("5 - Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 5)
                    return choice;

                Console.WriteLine("Invalid input! Please enter a number between 1 and 5.");
            }
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
