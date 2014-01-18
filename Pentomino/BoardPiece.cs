using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    // Not a great name, but we need an object that represents the combination of a particular board state and a piece.
    public class BoardPiece
    {
        public Board Board { get; private set; }
        public Piece Piece { get; private set; }
        public BoardPiece(Board board, Piece piece)
        {
            Board = board;
            Piece = piece;
        }
        public override int GetHashCode()
        {
            return Board.GetHashCode() ^ Piece.GetHashCode();
        }
    }
}
