using System;
using System.Globalization;
using System.Text;

namespace ConsoleApp20210616
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Intro
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Hello there! Give the string you wish to convert: \n");
            Console.ForegroundColor = ConsoleColor.White; 
            #endregion

            #region Variables
            string userInput = Console.ReadLine();
            string toLowerUserInput = userInput.ToLower().ToString();
            string convertedInput = string.Empty;
            bool checkForSigma = toLowerUserInput.Contains("σ");
            #endregion

            #region MainApp
            if (checkForSigma == true)
            {
                try
                {
                    convertedInput = ConvertToFinalSigma(toLowerUserInput);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Result: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\n {convertedInput} \n");
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Could not convert! Result: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\n {toLowerUserInput} \n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n No changes were made! \n");
                Console.ForegroundColor = ConsoleColor.White;
            } 
            #endregion

            Console.ReadKey();

        } // END static void Main(string[] args)

        private static string ConvertToFinalSigma(string toLowerUserInput)
        {
            #region Variables
            char[] seperator = { ' ' };
            string[] words = toLowerUserInput.Split(seperator);
            string tempStr = string.Empty;
            StringBuilder strBuilder = new StringBuilder();
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo; 
            #endregion

            foreach (var word in words)
            {
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    var lastChar = word[i];

                    if (char.IsLetter(lastChar))
                    {
                        if (lastChar == 'σ')
                        {
                            tempStr = word.Remove(i, 1).Insert(i, "ς").ToString();
                        }
                        else
                        {
                            tempStr = word.ToString();
                        }

                        strBuilder.Append(tempStr + " ");
                        break;
                    }
                }
            }

            string final = strBuilder.ToString().TrimEnd(' ');

            return ti.ToTitleCase(final);

        } // end private static string ConvertToFinalSigma(string toLowerUserInput)

    } // END class Program

} // END namespace ConsoleApp20210616
