using DominoCircularChainChallenge.Core;
using DominoCircularChainChallenge.Services;
using DominoCircularChainChallenge.Utilities;

internal class Program
{
    private static void Main(string[] args)
    {
        /// <summary>
        /// Entry point for the application that interacts with the user to generate and process dominoes.
        /// </summary>
        Console.WriteLine("Hello, Tester!");

        // Create instances of the required dependencies
        var dominoGenerator = new DominoGenerator();
        var dominoChainSolver = new DominoChainSolver();

        // Create the DominoProcessor with the dependencies
        var dominoProcessor = new DominoProcessor(dominoGenerator, dominoChainSolver);

        do
        {
            // Prompt the user to decide if they want a successful domino chain
            Console.WriteLine("Do you want the domino chain to be successful? (y/n)");
            bool isSuccessfulChain = Console.ReadLine().Trim().Equals("y", StringComparison.CurrentCultureIgnoreCase);

            // Get the number of dominoes to generate
            int count = InputHandler.GetDominoCount();

            // Process the dominoes based on the user's choices
            dominoProcessor.ProcessDominoes(count, isSuccessfulChain);

            // Ask the user if they want to generate another set of dominoes
            Console.WriteLine("\nWould you like to generate another set of dominoes? (y/n)");
        }
        while (Console.ReadLine().Trim().Equals("y", StringComparison.CurrentCultureIgnoreCase)); // Continue if the user inputs 'y'

        Console.WriteLine("Goodbye!"); // End the program
    }
}