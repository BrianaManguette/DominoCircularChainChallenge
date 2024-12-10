using DominoCircularChainChallenge.Models;
using DominoCircularChainChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCircularChainChallenge.Tests.Services
{
    public class DominoChainSolverTests
    {
        private readonly DominoChainSolver _solver;

        public DominoChainSolverTests()
        {
            _solver = new DominoChainSolver();
        }

        [Fact]
        public void FindCircularChain_ValidChain_ReturnsCorrectChain()
        {
            // Arrange: A set of dominoes that forms a valid circular chain
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 3),
                new Domino(3, 1)
            };

            // Act: Try to find the circular chain
            var result = _solver.FindCircularChain(dominoes);

            // Assert: The result should be the same dominoes in a circular chain
            Assert.NotNull(result);
            Assert.Equal(dominoes.Count, result.Count);
            Assert.True(_solver.IsValidChain(result));
        }

        [Fact]
        public void FindCircularChain_NoValidChain_ReturnsNull()
        {
            // Arrange: A set of dominoes that do not form a circular chain
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(3, 4),
                new Domino(5, 6)
            };

            // Act: Try to find a circular chain
            var result = _solver.FindCircularChain(dominoes);

            // Assert: The result should be null since no circular chain is possible
            Assert.Null(result);
        }

        [Fact]
        public void IsValidChain_ValidChain_ReturnsTrue()
        {
            // Arrange: A valid circular chain
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 3),
                new Domino(3, 1)
            };

            // Act: Validate the chain
            var result = _solver.IsValidChain(dominoes);

            // Assert: The result should be true because this is a valid circular chain
            Assert.True(result);
        }

        [Fact]
        public void IsValidChain_InvalidChain_ReturnsFalse()
        {
            // Arrange: An invalid chain (the right side does not match the next domino's left side)
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(3, 4),
                new Domino(4, 5)
            };

            // Act: Validate the chain
            var result = _solver.IsValidChain(dominoes);

            // Assert: The result should be false because this is not a valid chain
            Assert.False(result);
        }

        [Fact]
        public void GeneratePermutations_GeneratesCorrectPermutations()
        {
            // Arrange: A small set of dominoes
            var dominoes = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(2, 3)
            };

            // Act: Generate all permutations
            var permutations = _solver.GeneratePermutations(dominoes);

            // Assert: We expect 2 permutations (since there are 2 dominoes)
            Assert.Equal(2, permutations.Count);

            // We expect the permutations to be (1, 2) -> (2, 3) and (2, 3) -> (1, 2)
            var firstPermutation = permutations.First();
            var secondPermutation = permutations.Last();

            Assert.Contains(new Domino(1, 2), firstPermutation);
            Assert.Contains(new Domino(2, 3), firstPermutation);

            Assert.Contains(new Domino(1, 2), secondPermutation);
            Assert.Contains(new Domino(2, 3), secondPermutation);
        }
    }
}
