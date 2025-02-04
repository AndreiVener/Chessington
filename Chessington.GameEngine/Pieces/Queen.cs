﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMovesLines = GetAvailableMovesLine(currentSquare, board).ToList();
            var availableMovesDiagonally = GetAvailableMovesDiagonally(currentSquare, board).ToList();
            return availableMovesLines.Concat(availableMovesDiagonally).ToList();
        }
    }
}