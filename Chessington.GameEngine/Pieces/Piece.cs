using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            
            Player = player;
        }

        public Player Player { get; private set; }
        public bool Moved { get; set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            Moved = true;
        }

        public List<Square> GetAvailableMovesLine(Square currentSquare, Board board)
        {
            List<Square> availablePositions = new List<Square>();
            
            var up = Square.At(currentSquare.Row - 1, currentSquare.Col);
            while (up.IsSquareValid(board))
            {
                availablePositions.Add(up);
                up = Square.At(up.Row - 1, up.Col);
            }
            
            var right = Square.At(currentSquare.Row , currentSquare.Col+1);
            while (right.IsSquareValid(board))
            {
                availablePositions.Add(right);
                right = Square.At(right.Row, right.Col + 1);

            }
            
            var left = Square.At(currentSquare.Row , currentSquare.Col-1);
            while (left.IsSquareValid(board))
            {
                availablePositions.Add(left);
                left = Square.At(left.Row, left.Col - 1);

            }
            
            var down = Square.At(currentSquare.Row + 1 , currentSquare.Col);
            while (down.IsSquareValid(board))
            {
                availablePositions.Add(down);
                down = Square.At(down.Row + 1, down.Col);

            }

            return availablePositions;
        }

        public List<Square> GetAvailableMovesDiagonally(Square currentSquare, Board board)
        {
            List<Square> availablePositions = new List<Square>();
            var leftUp = Square.At(currentSquare.Row - 1, currentSquare.Col-1);
            while (leftUp.IsSquareValid(board))
            {
                availablePositions.Add(leftUp);
                leftUp = Square.At(leftUp.Row - 1, leftUp.Col - 1);
            }
            
            var rightUp = Square.At(currentSquare.Row - 1, currentSquare.Col+1);
            while (rightUp.IsSquareValid(board))
            {
                availablePositions.Add(rightUp);
                rightUp = Square.At(rightUp.Row - 1, rightUp.Col + 1);
            }
            var leftDown = Square.At(currentSquare.Row + 1, currentSquare.Col-1);
            while (leftDown.IsSquareValid(board))
            {
                availablePositions.Add(leftDown);
                leftDown = Square.At(leftDown.Row + 1, leftDown.Col - 1);
            }
            
            var rightDown = Square.At(currentSquare.Row + 1, currentSquare.Col+1);
            while (rightDown.IsSquareValid(board))
            {
                availablePositions.Add(rightDown);
                rightDown = Square.At(rightDown.Row + 1, rightDown.Col + 1);
            }
            return availablePositions;
        }



    }
}