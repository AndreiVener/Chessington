namespace Chessington.GameEngine
{
    public struct Square
    {
        public readonly int Row;
        public readonly int Col;

        public Square(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public bool IsSquareInsideBorders()
        {
            if (Row < 0 || Row >= GameSettings.BoardSize || Col < 0 || Col >= GameSettings.BoardSize) return false;
            return true;
        }

        public bool IsSquareValid(Board board)
        {
            if (!IsSquareInsideBorders()) return false;
            if (IsSquareOccupied(board)) return false;
            return true;
        }

        public bool IsSquareOccupied(Board board)
        {
            if (board.GetPiece(this) != null) return true;
            return false;
        }

        public bool IsSquareOccupiedByEnemy(Board board,Player player)
        {
            if (IsSquareInsideBorders() && IsSquareOccupied(board) &&
                board.GetPiece(this).Player != player) return true;
            return false;
        }

        public static Square At(int row, int col)
        {
            return new Square(row, col);
        }

        public bool Equals(Square other)
        {
            return Row == other.Row && Col == other.Col;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Square && Equals((Square)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Col;
            }
        }

        public static bool operator ==(Square left, Square right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Square left, Square right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return string.Format("Row {0}, Col {1}", Row, Col);
        }
    }
}