using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCircularChainChallenge.Models
{
    public class Domino
    {
        public int Left { get; set; }
        public int Right { get; set; }

        public Domino(int left, int right)
        {
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Returns a string representation of the Domino object, formatted as "[Left|Right]".
        /// This method is useful for showing the left and right values of the domino separated by a vertical bar.
        /// </summary>
        /// <returns>A string in the format "[Left|Right]" representing the domino.</returns>
        public override string ToString()
        {
            return $"[{Left}|{Right}]";
        }

        // Override Equals to compare dominoes based on their Left and Right values
        public override bool Equals(object obj)
        {
            if (obj is Domino other)
            {
                return this.Left == other.Left && this.Right == other.Right;
            }
            return false;
        }

        // Override GetHashCode to ensure consistent hash code when comparing dominoes
        public override int GetHashCode()
        {
            return (Left, Right).GetHashCode();
        }
    }
}
