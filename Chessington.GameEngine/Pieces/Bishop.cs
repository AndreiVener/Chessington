using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availablePositions = new List<Square>();
            var currentSquare = board.FindPiece(this);

            availablePositions = GetAvailableMovesDiagonally(currentSquare,board);
            return availablePositions.AsEnumerable();
        }
    }
}