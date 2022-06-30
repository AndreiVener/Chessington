using System.Collections.Generic;

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

        protected IEnumerable<Square> GetAvailableMovesLine(Square currentSquare, Board board)
        {
            List<Square> availablePositions = new List<Square>();

            int[] rowDir = { 0, 0, 1, -1 };
            int[] colDir = { 1, -1, 0, 0 };

            for (var at = 0; at < rowDir.Length; at++)
            {
                var l = GoInDirection(board, rowDir[at], colDir[at], currentSquare);
                availablePositions.AddRange(l);
            }

            availablePositions.RemoveAll(square => square.Equals(currentSquare));
            return availablePositions;
        }

        protected IEnumerable<Square> GetAvailableMovesDiagonally(Square currentSquare, Board board)
        {
            var availablePositions = new List<Square>();

            int[] rowDir = { 1, -1, 1, -1 };
            int[] colDir = { 1, 1, -1, -1 };

            for (var at = 0; at < rowDir.Length; at++)
            {
                var l = GoInDirection(board, rowDir[at], colDir[at], currentSquare);
                availablePositions.AddRange(l);
            }

            availablePositions.RemoveAll(square => square.Equals(currentSquare));
            return availablePositions;
        }

        private IEnumerable<Square> GoInDirection(Board board, int rowDir, int colDir, Square atSquare)
        {
            var currentSquare = atSquare;
            var availablePositions = new List<Square>();
            while (atSquare.IsSquareValid(board) || atSquare.Equals(currentSquare))
            {
                availablePositions.Add(atSquare);
                atSquare = Square.At(atSquare.Row + rowDir, atSquare.Col + colDir);
            }

            if (atSquare.IsSquareInsideBorders() && board.GetPiece(atSquare).Player != Player)
            {
                availablePositions.Add(atSquare);
            }

            return availablePositions;
        }
    }
}