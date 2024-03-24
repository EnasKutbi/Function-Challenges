using System;

namespace FunctionChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            // Challenge 1: String and Number Processor
            Console.WriteLine("Challenge 1: String and Number Processor");
            StringNumberProcessor("Hello", 100, 200, "World"); // Expected outcome: "Hello World; 300"

            // Challenge 2: Object Swapper
            Console.WriteLine("\nChallenge 2: Object Swapper");
            int num1 = 25, num2 = 30;
            int num3 = 10, num4 = 30;
            string str1 = "HelloWorld", str2 = "Programming";
            string str3 = "Hi", str4 = "Programming";
                          
            SwapObjects(ref num1, ref num2); // Expected outcome: num1 = 30, num2 = 25  
            SwapObjects(ref num3, ref num4); // Error: Value must be more than 18

            SwapObjects(ref str1, ref str2); // Expected outcome: str1 = "Programming", str2 = "HelloWorld"
            SwapObjects(ref str3, ref str4); // Error: Length must be more than 5

            SwapObjects(true, false); // Error: Upsupported data type
            SwapObjects(num1, str1); // Error: Objects must be of same types

            Console.WriteLine($"Numbers: {num1}, {num2}");
            Console.WriteLine($"Strings: {str1}, {str2}");

            // Challenge 3: Guessing Game
            Console.WriteLine("\nChallenge 3: Guessing Game");
            // Uncomment to test the GuessingGame method
            GuessingGame(); // Expected outcome: User input until the correct number is guessed or user inputs `Quit`

            // Challenge 4: Simple Word Reversal
            Console.WriteLine("\nChallenge 4: Simple Word Reversal");
            string sentence = "This is the original sentence!";
            string reversed = ReverseWords(sentence);
            Console.WriteLine(reversed); // Expected outcome: "sihT si eht lanigiro !ecnetnes"
        }

        /*Challenge 1: String and Number Processor*/
        public static void StringNumberProcessor(params object[] input)
        {
            try
            {
                int numbers = 0;
                string sentence = "";
                foreach (var item in input)
                {
                    if (item is string)
                    {
                        sentence += " " + item;
                    }
                    else if (item is int)
                    {
                        numbers += (int)item;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                Console.WriteLine($"{sentence}; {numbers}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /*Challenge 2: Object Swapper*/
        public static void SwapObjects(ref int value1, ref int value2){
            int tempValue = value1;
            if (value1 > 18 && value2 > 18)
            {
                value1 = value2;
                value2 = tempValue;
            }
            else {
                Console.WriteLine($"{value1} & {value2} the Numbers must be more than 18");
            }
        }

        public static void SwapObjects(ref string value1, ref string value2)
        {
            string tempValue = value1;
            if (value1.Length > 5 && value2.Length > 5)
            {
                value1 = value2;
                value2 = tempValue;
            }
            else
            {
                Console.WriteLine($"{value1} & {value2} the lengths must be more than 5");
            }
        }

        public static void SwapObjects(object value1, object value2)
        {
            try
            {
                object tempValue = value1;
                if (value1.GetType() == value2.GetType())
                {
                    value1 = value2;
                    value2 = tempValue;
                }
                else
                {
                    Console.WriteLine($"{value1} & {value2} Objects must be the same types");
                }
                if (value1 is bool || value2 is bool)
                {
                    Console.WriteLine($"{value1} & {value2} Unsupported data type");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /*Challenge 3: Guessing Game*/
        public static void GuessingGame()
        {
            try
            {
                Random random = new Random();
                int randomNum = random.Next(1, 100);
                while (true)
                {
                    Console.Write("Enter the Number you Guess Between 1 to 100: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int guessNum))
                    {
                        Console.WriteLine("Invalid input. Please enter a Number between 1 to 100.");
                        continue;
                    }
                    if (guessNum > 100 || guessNum < 1)
                    {
                        Console.WriteLine("Invalid input. Please enter a Number between 1 to 100.");
                        continue;
                    }
                    if (guessNum == randomNum)
                    {
                        Console.WriteLine("Well done, you guessed the number");
                        break;
                    }
                    else if (guessNum > randomNum)
                    {
                        Console.WriteLine("The number you guessed is bigger than the number");
                        continue;
                    }
                    else if (guessNum < randomNum)
                    {
                        Console.WriteLine("The number you guessed is smaller than the number");
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /*Challenge 4: Simple Word Reversal*/
        public static string ReverseWords(string input){
                string[] sentence = input.Trim().Split(" ");
                string reversedSentence = "";
                foreach (string word in sentence)
                {
                    string reversedWord = new string(word.Reverse().ToArray());
                    reversedSentence += reversedWord + " ";
                }
                return reversedSentence;
        }
    }
}
