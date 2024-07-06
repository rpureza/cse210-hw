

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Define the scripture with its reference and text
        Scripture john316 = new Scripture
        {
            Reference = "John 3:16",
            Text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
        };

        // Split the scripture text into words
        string[] words = john316.Text.Split(' ');

        // List to keep track of hidden words
        List<int> hiddenIndexes = new List<int>();

        // Main loop to interact with user
        while (hiddenIndexes.Count < words.Length)
        {
            Console.Clear();
            // Display the scripture with hidden words
            Console.WriteLine($"Scripture: {john316.Reference}");
            for (int i = 0; i < words.Length; i++)
            {
                if (hiddenIndexes.Contains(i))
                    Console.Write("______ ");
                else
                    Console.Write($"{words[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;
            
            // Hide a few random words
            HideRandomWords(words.Length, hiddenIndexes);
        }

        Console.WriteLine("Program ended. Press any key to exit.");
        Console.ReadKey();
    }

    // Method to hide a few random words
    static void HideRandomWords(int totalWords, List<int> hiddenIndexes)
    {
        Random random = new Random();
        int wordsToHide = totalWords / 4; // Hide approximately 25% of words

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(totalWords);
            if (!hiddenIndexes.Contains(index))
                hiddenIndexes.Add(index);
        }
    }
}

// Class to represent a Scripture
class Scripture
{
    public string Reference { get; set; }
    public string Text { get; set; }
}
