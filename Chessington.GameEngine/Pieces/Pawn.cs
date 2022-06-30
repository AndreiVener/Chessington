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
                var inFrontSquare = new Square(currentSquare.Row - 1, currentSquare.Col);
                Console.WriteLine(inFrontSquare.Row + " " + inFrontSquare.Col);

                var pieceInFront = board.GetPiece(inFrontSquare);
                if (pieceInFront == null)
                {
                    availablePositions.Add(inFrontSquare);
                }
            }
            else
            {
                var inFrontSquare = new Square(currentSquare.Row + 1, currentSquare.Col);
                var pieceInFront = board.GetPiece(inFrontSquare);
                if (pieceInFront == null)
                {
                    availablePositions.Add(inFrontSquare);
                }
            }
            
            return availablePositions.AsEnumerable();
        }
    }
}