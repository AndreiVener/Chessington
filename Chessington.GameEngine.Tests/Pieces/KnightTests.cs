using System;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KnightTests
    {
        [Test]
        public void Knight_CanMoveAtCorrectPositions()
        {
            //Given
            var board = new Board();
            var knight = new Knight(Player.White);

            //When
            board.AddPiece(Square.At(4, 4), knight);
            var moves = knight.GetAvailableMoves(board);
          
            //Then
            moves.Should().Contain(Square.At(2, 5));
            moves.Should().Contain(Square.At(2, 3));
            moves.Should().Contain(Square.At(3, 6));
            moves.Should().Contain(Square.At(5, 6));
            moves.Should().Contain(Square.At(6, 3));
            moves.Should().Contain(Square.At(6, 5));
            moves.Should().Contain(Square.At(3, 2));
            moves.Should().Contain(Square.At(5, 2));

        }
        [Test]
        public void Knight_CanMoveWhenInCorner()
        {
            //Given
            var board = new Board();
            var knight = new Knight(Player.White);

            //When
            board.AddPiece(Square.At(0, 0), knight);
            var moves = knight.GetAvailableMoves(board);
          
            //Then
            moves.Should().Contain(Square.At(2, 1));
            moves.Should().Contain(Square.At(1, 2));
           

        }
    }
}