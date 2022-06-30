using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availablePositions = new List<Square>();
            var currentSquare = board.FindPiece(this);
            int row = currentSquare.Row;
            int col = currentSquare.Col;

            int[] rowPos = new[] { -2, -2, 1, -1, 2, 2, 1, -1 };
            int[] colPos = new[] { 1, -1, 2, 2, 1, -1, -2, -2 };
            
            for(int at = 0; at < 8; at++)
            {

                var possiblePosition = new Square(currentSquare.Row + rowPos[at], currentSquare.Col + colPos[at]);
                if(!possiblePosition.IsSquareValid(board) || board.GetPiece(possiblePosition) != null) continue;
                availablePositions.Add(possiblePosition);
                                
            }
            return availablePositions.AsEnumerable();
        }
    }
}