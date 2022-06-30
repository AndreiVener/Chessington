using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availableMoves = new List<Square>();
            int[] rowPos = {-1,-1,-1,0,0,1,1,1 };
            int[] colPos = { -1,0,1,-1,1,-1,0,1};
            Square currentposition = board.FindPiece(this);
            for (int at = 0; at < rowPos.Length; at++)
            {
                Square possiblePosition = Square.At(currentposition.Row + rowPos[at],currentposition.Col + colPos[at]);
                if (possiblePosition.IsSquareValid(board))
                {
                    availableMoves.Add(possiblePosition);
                }
            }

            return availableMoves;

        }
    }
}