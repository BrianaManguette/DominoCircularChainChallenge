using DominoCircularChainChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCircularChainChallenge.Interfaces
{
    public interface IDominoChainSolver
    {
        List<Domino> FindCircularChain(List<Domino> dominoes);
        bool IsValidChain(List<Domino> chain);
        List<List<Domino>> GeneratePermutations(List<Domino> dominoes);
    }
}
