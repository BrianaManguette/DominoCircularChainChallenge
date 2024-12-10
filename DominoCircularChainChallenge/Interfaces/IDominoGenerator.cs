using DominoCircularChainChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCircularChainChallenge.Interfaces
{
    public interface IDominoGenerator
    {
        List<Domino> GenerateRandomDominoes(int count);
        List<Domino> GenerateSuccessfulDominoes(int count);
    }
}
