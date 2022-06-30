using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            int[] rowPos = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colPos = { -1, 0, 1, -1, 1, -1, 0, 1 };
            var currentPosition = board.FindPiece(this);
            
            for (var at = 0; at < rowPos.Length; at++)
            {
                var possiblePosition = Square.At(currentPosition.Row + rowPos[at], currentPosition.Col + colPos[at]);

                if (possiblePosition.IsSquareValid(board))
                {
                    availableMoves.Add(possiblePosition);
                }
                if (possiblePosition.IsSquareOccupiedByEnemy(board,Player))
                    availableMoves.Add(possiblePosition);
            }

            return availableMoves;
        }
    }
}