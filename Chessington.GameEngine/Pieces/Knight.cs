using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availablePositions = new List<Square>();
            var currentSquare = board.FindPiece(this);

            var rowPos = new[] { -2, -2, 1, -1, 2, 2, 1, -1 };
            var colPos = new[] { 1, -1, 2, 2, 1, -1, -2, -2 };

            for (var at = 0; at < 8; at++)
            {
                var possiblePosition = new Square(currentSquare.Row + rowPos[at], currentSquare.Col + colPos[at]);
                if (possiblePosition.IsSquareValid(board))
                {
                    availablePositions.Add(possiblePosition);
                }
                if (possiblePosition.IsSquareInsideBorders() && possiblePosition.IsSquareOccupied(board) &&
                    board.GetPiece(possiblePosition).Player != Player)
                    availablePositions.Add(possiblePosition);
            }

            return availablePositions.AsEnumerable();
        }
    }
}