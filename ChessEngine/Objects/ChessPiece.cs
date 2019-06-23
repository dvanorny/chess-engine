
namespace ChessEngine
{
    public class ChessPiece
    {
        public ChessPiece(Enums.Piece name, Enums.Color color)
        {
            Name = name;
            Color = color;
        }
        public Enums.Piece Name { get; set; }
        public Enums.Color Color { get; set; }
        public string LegalMove { get; set; }
        public string Location { get; set; }

        public int PieceValue()
        {
            if (Name == Enums.Piece.Bishop || Name == Enums.Piece.Knight) { return 3; }
            if (Name == Enums.Piece.Rook) { return 5; }
            if (Name == Enums.Piece.Queen) { return 9; }
            if (Name == Enums.Piece.Pawn) { return 1; }
            if (Name == Enums.Piece.King) { return 250; }
            return 0;

        }
    }
}
