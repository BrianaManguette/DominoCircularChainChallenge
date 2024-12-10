using DominoCircularChainChallenge.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCircularChainChallenge.Tests.Utilities
{
    public class InputHandlerTests
    {
        [Fact]
        public void GetDominoCount_ReturnsValidCount_WhenInputIsValid()
        {
            var userInput = "5\n";
            var reader = new StringReader(userInput);
            Console.SetIn(reader);

            int count = InputHandler.GetDominoCount();

            Assert.Equal(5, count);
        }

        [Fact]
        public void GetDominoCount_PromptsAgain_WhenInputIsInvalid()
        {
            var userInput = "15\n5\n";
            var reader = new StringReader(userInput);
            Console.SetIn(reader);

            int count = InputHandler.GetDominoCount();

            Assert.Equal(5, count);
        }
    }
}
