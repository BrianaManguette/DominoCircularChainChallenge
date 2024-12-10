using DominoCircularChainChallenge.Interfaces;
using DominoCircularChainChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCircularChainChallenge.Services
{
    public class DominoGenerator : IDominoGenerator
    {
        private readonly Random _random;

        public DominoGenerator()
        {
            _random = new Random();
        }

        /// <summary>
        /// Generates a list of random dominoes without guaranteeing a successful circular chain.
        /// </summary>
        /// <param name="count">The number of dominoes to generate.</param>
        /// <returns>A list of randomly generated dominoes.</returns>
        public List<Domino> GenerateRandomDominoes(int count)
        {
            var random = new Random();
            var dominoes = new HashSet<string>(); // To avoid duplicate dominoes
            var result = new List<Domino>();

            // Generate random dominoes until the desired count is reached
            while (result.Count < count)
            {
                int left = random.Next(1, 6); // Generate a random number for the left side (1 to 5)
                int right = random.Next(1, 6); // Generate a random number for the right side (1 to 5)

                // Create a unique key for the domino to avoid duplicates (e.g., "2|3" or "3|2")
                string dominoKey = left <= right ? $"{left}|{right}" : $"{right}|{left}";
                if (!dominoes.Contains(dominoKey)) // Check for duplicates
                {
                    dominoes.Add(dominoKey); // Add the domino to the set
                    result.Add(new Domino(left, right)); // Add the domino to the result list
                }
            }

            return result; // Return the generated list of dominoes
        }

        /// <summary>
        /// Generates a list of dominoes that form a guaranteed successful circular chain.
        /// </summary>
        /// <param name="count">The number of dominoes to generate.</param>
        /// <returns>A list of randomly generated dominoes.</returns>
        public List<Domino> GenerateSuccessfulDominoes(int count)
        {
            var random = new Random();
            var result = new List<Domino>();

            // Initialize the chain with a random starting number
            int current = random.Next(1, 6); // Random starting number between 1 and 5
            for (int i = 0; i < count - 1; i++)
            {
                int next = random.Next(1, 6); // Generate the next number in the chain
                result.Add(new Domino(current, next)); // Add the domino to the chain
                current = next; // Move to the next number in the chain
            }

            // Close the chain by connecting the last domino back to the first
            result.Add(new Domino(current, result[0].Left));

            return result; // Return the generated circular chain
        }
    }
}
