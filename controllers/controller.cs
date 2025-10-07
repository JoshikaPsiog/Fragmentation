using System;
using System.IO;
using models.model;
using view.views;

namespace controllers.controller
{
    class ParagraphController
    {
        public void Run()
        {
            FragmentationView view = new FragmentationView();
            SplitterModel model = new SplitterModel();

            string paragraph = view.GetParagraph();
            File.WriteAllText("input.txt", paragraph);
            view.DisplayMessage("\nParagraph saved to input.txt");

            int charsPerFile = view.GetCharsPerFile();
            int totalFiles = model.SplitParagraph(paragraph, charsPerFile);
            view.DisplayMessage($"\nParagraph split into {totalFiles} files successfully!");
            string compare = "";

            while (true)
            {
                int choice = view.ShowMenu();

                if (choice == 1)
                {
                    int fileNum = view.AskFileNumber(totalFiles);
                    string content = model.ViewFile(fileNum, totalFiles);
                    view.DisplayFile($"{fileNum}.txt", content);
                }
                else if (choice == 2)
                {
                    compare = model.CombineFiles(totalFiles);
                    view.DisplayMessage("\nAll split files combined into output.txt!");
                }
                else if (choice == 3)
                {
                    foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt"))
                    {
                        File.Delete(file);  // deletes everything including input.txt and output.txt
                    }
                    view.DisplayMessage("\nAll txt files are deleted");
                }

                else if (choice == 4)
                {
                    view.DisplayMessage("\nchecking Input and Output files");
                    if (compare == paragraph)
                    {
                        view.DisplayMessage("\n both are same");
                    }
                    else
                    {
                        view.DisplayMessage("not same");
                    }
                    
                }
                else if (choice == 5)
                {
                    view.DisplayMessage("\nExiting program...");
                    break;
                }
                else
                {
                    view.DisplayMessage("Invalid choice, try again!");
                }
            }
        }
    }
}
