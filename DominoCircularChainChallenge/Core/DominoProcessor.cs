using DominoCircularChainChallenge.Interfaces;
using DominoCircularChainChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCircularChainChallenge.Core
{
    public class DominoProcessor
    {
        private bool isProcessingComplete = false;
        private readonly IDominoGenerator _dominoGenerator;
        private readonly IDominoChainSolver _dominoChainSolver;

        // Modify constructor to accept dependencies
        public DominoProcessor(IDominoGenerator dominoGenerator, IDominoChainSolver dominoChainSolver)
        {
            _dominoGenerator = dominoGenerator;
            _dominoChainSolver = dominoChainSolver;
        }

        /// <summary>
        /// Processes the generation and evaluation of dominoes to determine if a circular chain is possible.
        /// </summary>
        /// <param name="count">The number of dominoes to generate.</param>
        /// <param name="isSuccessfulChain">Indicates whether to generate a guaranteed successful chain.</param>
        public void ProcessDominoes(int count, bool isSuccessfulChain)
        {
            // Start a separate thread to show the loading spinner
            var loadingThread = new System.Threading.Thread(() =>
            {
                if(!isProcessingComplete)
                    Console.Write($"Processing dominoes...");
            });
            loadingThread.Start();

            // Generate dominoes based on the user's choice:
            var dominoes = isSuccessfulChain
                ? _dominoGenerator.GenerateSuccessfulDominoes(count)
                : _dominoGenerator.GenerateRandomDominoes(count);

            // Use the solver to attempt finding a circular chain
            var result = _dominoChainSolver.FindCircularChain(dominoes);

            // Set processing as complete and stop the loading indicator
            isProcessingComplete = true;  // Stop the loading spinner
            loadingThread.Join();  // Wait for the loading thread to finish

            // Display results (console output) or use return values for testing
            if (result != null)
            {
                Console.WriteLine("\nCircular chain is possible:");
                Console.WriteLine(string.Join(" -> ", result)); // Display the successful chain
            }
            else
            {
                Console.WriteLine("\nIt's not possible to form a circular chain.");
            }
        }
    }
}
