using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availablePositions = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var rowDir = Player == Player.White ? new[] { -1, -2 } : new[] { 1, 2 };
            
            var inFrontSquare = Square.At(currentSquare.Row + rowDir[0], currentSquare.Col);
            if (inFrontSquare.IsSquareValid(board))
            {
                availablePositions.Add(inFrontSquare);
            }
            else
            {
                return Enumerable.Empty<Square>();
            }

            var inFrontTwoSquares = Square.At(currentSquare.Row + rowDir[1], currentSquare.Col);
            if (Moved == false && inFrontTwoSquares.IsSquareValid(board))
            {
                availablePositions.Add(inFrontTwoSquares);
            }

            var diagonalSquare = Square.At(currentSquare.Row +rowDir[0], currentSquare.Col - 1);
            if (diagonalSquare.IsSquareOccupiedByEnemy(board, Player))
            {
                availablePositions.Add(diagonalSquare);
            }
            
            diagonalSquare = Square.At(currentSquare.Row + rowDir[0], currentSquare.Col + 1);
            if (diagonalSquare.IsSquareOccupiedByEnemy(board, Player))
            {
                availablePositions.Add(diagonalSquare);
            }
            
            return availablePositions.AsEnumerable();
        }
    }
}