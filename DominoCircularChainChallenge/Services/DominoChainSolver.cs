using DominoCircularChainChallenge.Interfaces;
using DominoCircularChainChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCircularChainChallenge.Services
{
    public class DominoChainSolver : IDominoChainSolver
    {
        /// <summary>
        /// Attempts to find a circular chain of dominoes from a given list.
        /// </summary>
        /// <param name="dominoes">The list of dominoes to evaluate.</param>
        /// <returns>A valid circular chain if found, otherwise null.</returns>
        public List<Domino> FindCircularChain(List<Domino> dominoes)
        {
            // Generate all possible permutations of the dominoes
            var permutations = GeneratePermutations(dominoes);

            // Check each permutation to see if it forms a valid circular chain
            foreach (var chain in permutations)
            {
                if (IsValidChain(chain)) // If a valid chain is found, return it
                {
                    return chain;
                }
            }

            // Return null if no valid circular chain exists
            return null;
        }

        /// <summary>
        /// Validates whether the given chain of dominoes forms a circular chain.
        /// </summary>
        /// <param name="chain">The list of dominoes to validate.</param>
        /// <returns>True if the chain is a valid circular chain, otherwise false.</returns>
        public bool IsValidChain(List<Domino> chain)
        {
            for (int i = 0; i < chain.Count; i++)
            {
                var current = chain[i];
                var next = chain[(i + 1) % chain.Count]; // Use modulo to wrap around for circular validation

                // If the right value of the current domino does not match the left value of the next domino
                if (current.Right != next.Left)
                    return false; // Chain is invalid
            }
            return true; // Chain is valid
        }

        /// <summary>
        /// Generates all possible permutations of a list of dominoes.
        /// </summary>
        /// <param name="dominoes">The list of dominoes to permute.</param>
        /// <returns>A list of all possible permutations of the given dominoes.</returns>
        public List<List<Domino>> GeneratePermutations(List<Domino> dominoes)
        {
            // Base case: if only one domino, return it as the sole permutation
            if (dominoes.Count == 1) return new List<List<Domino>> { dominoes };

            var permutations = new List<List<Domino>>();

            // Iterate through each domino, treating it as the starting element
            foreach (var domino in dominoes)
            {
                // Create a list of the remaining dominoes
                var remaining = new List<Domino>(dominoes);
                remaining.Remove(domino);

                // Generate permutations of the remaining dominoes
                foreach (var perm in GeneratePermutations(remaining))
                {
                    // Insert the current domino at the beginning of each permutation
                    perm.Insert(0, domino);
                    permutations.Add(perm);
                }
            }

            return permutations; // Return all generated permutations
        }
    }
}
