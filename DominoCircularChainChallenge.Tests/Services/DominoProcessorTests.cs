using Moq;
using Xunit;
using DominoCircularChainChallenge.Interfaces;
using DominoCircularChainChallenge.Services;
using System;
using System.Collections.Generic;
using System.IO;
using DominoCircularChainChallenge.Core;
using DominoCircularChainChallenge.Models;

namespace DominoCircularChainChallenge.Tests
{
    public class DominoProcessorTests
    {
        [Fact]
        public void ProcessDominoes_DisplaysProcessingMessage_And_HandlesResult()
        {
            // Arrange
            var mockDominoGenerator = new Mock<IDominoGenerator>();
            var mockDominoChainSolver = new Mock<IDominoChainSolver>();

            // Set up the mock for generating random dominoes and solving the chain
            mockDominoGenerator.Setup(m => m.GenerateRandomDominoes(It.IsAny<int>())).Returns(new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 3),
                new Domino(3, 1)
            });

            mockDominoChainSolver.Setup(m => m.FindCircularChain(It.IsAny<List<Domino>>())).Returns(new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 3),
                new Domino(3, 1)
            });

            var processor = new DominoProcessor(mockDominoGenerator.Object, mockDominoChainSolver.Object);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // Redirect console output to capture it
                processor.ProcessDominoes(5, true); // Generate a successful chain
                var output = sw.ToString();

                // Assert that "Processing dominoes..." message is displayed
                Assert.Contains("Processing dominoes...", output);

                // Assert that the correct result (circular chain) is displayed
                Assert.Contains("Circular chain is possible:", output);
            }
        }

        [Fact]
        public void ProcessDominoes_DisplaysProcessingMessage_And_NoCircularChain()
        {
            // Arrange
            var mockDominoGenerator = new Mock<IDominoGenerator>();
            var mockDominoChainSolver = new Mock<IDominoChainSolver>();

            // Set up the mock for generating random dominoes and solving the chain
            mockDominoGenerator.Setup(m => m.GenerateRandomDominoes(It.IsAny<int>())).Returns(new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 3),
                new Domino(4, 5) // This will not form a circular chain
            });

            mockDominoChainSolver.Setup(m => m.FindCircularChain(It.IsAny<List<Domino>>())).Returns((List<Domino>)null); // No circular chain

            var processor = new DominoProcessor(mockDominoGenerator.Object, mockDominoChainSolver.Object);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // Redirect console output to capture it
                processor.ProcessDominoes(5, false); // Generate a random dominoes
                var output = sw.ToString();

                // Assert that "Processing dominoes..." message is displayed
                Assert.Contains("Processing dominoes...", output);

                // Assert that the correct result (no circular chain) is displayed
                Assert.Contains("It's not possible to form a circular chain.", output);
            }
        }
    }
}
