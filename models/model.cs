using System;
using System.IO;

namespace models.model
{
    class SplitterModel
    {
        public int SplitParagraph(string paragraph, int charsPerFile)
        {
            // Cleanup old files before splitting
            foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt"))
            {
                if (file.Contains("input.txt") || file.Contains("output.txt"))
                    continue;
                File.Delete(file);
            }

            int totalFiles = (paragraph.Length + charsPerFile - 1) / charsPerFile;
            int digits = totalFiles < 10 ? 1 : (totalFiles < 100 ? 2 : 3);

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

            return totalFiles;
        }

        public string ViewFile(int fileNum, int totalFiles)
        {
            int digits = totalFiles < 10 ? 1 : (totalFiles < 100 ? 2 : 3);

            string fileName = digits == 3 ? $"{fileNum.ToString("D3")}.txt" :
                              digits == 2 ? $"{fileNum.ToString("D2")}.txt" :
                              $"{fileNum}.txt";

            if (!File.Exists(fileName))
                return "File not found!";

            return File.ReadAllText(fileName);
        }

        public string CombineFiles(int totalFiles)
        {
            int digits = totalFiles < 10 ? 1 : (totalFiles < 100 ? 2 : 3);
            string combinedText = "";

            for (int i = 0; i < totalFiles; i++)
            {
                string fileName = digits == 3 ? $"{(i + 1).ToString("D3")}.txt" :
                                  digits == 2 ? $"{(i + 1).ToString("D2")}.txt" :
                                  $"{i + 1}.txt";

                combinedText += File.ReadAllText(fileName);
                
            }

            File.WriteAllText("output.txt", combinedText);
            return combinedText;
        }

       
    }
}
