using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {          
            List<Square> availablePositions = new List<Square>();
            var currentSquare = board.FindPiece(this);
            
            if (Player == Player.White)
            {
                var inFrontSquare = Square.At(currentSquare.Row - 1, currentSquare.Col);
                if (inFrontSquare.IsSquareValid(board))
                {
                    availablePositions.Add(inFrontSquare);
                }else
                {
                    return Enumerable.Empty<Square>();
                }

                var inFrontTwoSquares = Square.At(currentSquare.Row - 2, currentSquare.Col);
                if (Moved == false && inFrontTwoSquares.IsSquareValid(board))
                {
                    availablePositions.Add(inFrontTwoSquares);
                }
            }
            else
            {
                var inFrontSquare = Square.At(currentSquare.Row + 1, currentSquare.Col);
                if (inFrontSquare.IsSquareValid(board))
                {
                    availablePositions.Add(inFrontSquare);
                }
                else
                {
                    return Enumerable.Empty<Square>();
                }
                
                var inFrontTwoSquares = Square.At(currentSquare.Row + 2, currentSquare.Col);
                if (Moved == false && inFrontTwoSquares.IsSquareValid(board))
                {
                    availablePositions.Add(inFrontTwoSquares);
                }
            }
            
            return availablePositions.AsEnumerable();
        }
    }
}