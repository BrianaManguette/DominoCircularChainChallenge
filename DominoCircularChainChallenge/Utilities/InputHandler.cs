using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCircularChainChallenge.Utilities
{
    public static class InputHandler
    {
        /// <summary>
        /// Prompts the user to input the number of dominoes to generate and validates the input.
        /// </summary>
        /// <returns>An integer representing the valid number of dominoes (between 3 and 10).</returns>
        public static int GetDominoCount()
        {
            while (true) // Loop until valid input is provided
            {
                Console.WriteLine("How many dominoes would you like to generate? (Minimum: 3, Maximum: 10)");

                // Read input and attempt to parse it as an integer
                if (int.TryParse(Console.ReadLine(), out int count) && count >= 3 && count <= 10)
                {
                    return count; // Return the valid count
                }

                // If input is invalid, display an error message and prompt again
                Console.WriteLine("Invalid input. Please enter a number between 3 and 10.");
            }
        }
    }
}
