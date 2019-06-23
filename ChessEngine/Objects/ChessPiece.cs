
using System.Collections;

namespace ChessEngine
{
    public class ChessPiece 
    {
        public ChessPiece(Piece name, Color color)
        {
            Name = name;
            Color = color;
        }
        public Piece Name { get; set; }
        public Color Color { get; set; }
        public string LegalMove { get; set; }
        public string Location { get; set; }

        public int PieceValue()
        {
            if (Name == Piece.Bishop || Name == Piece.Knight) { return 3; }
            if (Name == Piece.Rook) { return 5; }
            if (Name == Piece.Queen) { return 9; }
            if (Name == Piece.Pawn) { return 1; }
            if (Name == Piece.King) { return 250; }
            return 0;

        }

    }
}
