using System;

namespace ChessEngine
{
    public class Fen
    {
        public ChessPiece[,] ConvertFenToBoard(string fenStr)
        {
            //Good article that explains it: https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation

            //Make a new Board
            var board = new ChessPiece[8, 8];

            //The location of the pieces is the string of numnbers and letter up to the first space
            //So find that string and set it to a new variable
            var locationOfPieces = fenStr.Substring(0, fenStr.IndexOf(" "));

            //Each rank is separated by a forward-slash, so let's make an array with 8 values -- one for each rank
            //The C# Split function can easily do this for us (each item within the 'ranks' array will be a series of letters/numbers)
            var ranks = locationOfPieces.Split("/");

            //Loop through each of the 8 ranks (starting with rank 1 and ending with rank 8)
            for (int i=0; i < 8; i++)
            {
                var rank = ranks[i];

                //Start a counter for this rank so we know what file we are currently looking at as we loop through the characters
                var ctr = 0;

                //Loop through each character in the string describing the pieces on this rank
                foreach (char c in rank)
                {
                    if (IsNumeric(c))
                    {
                        var number = Convert.ToInt16(c);

                        //If any number (1-8) exists in a FEN string then it indicates a series of board spaces where no piece exists
                        //   ...so we are going to increment our counter that number of spaces so the next time through this foreach loop it
                        //   will accurately know which file to place a piece on
                        ctr += number;
                    }

                    //A switch statement is an efficient way to do a bunch of if-elses in C#
                    switch (c)
                    {
                        //TODO: Finish filling in case statements
                        case 'r':
                            board[i, ctr] = new ChessPiece(Piece.Rook, Color.White);
                            break;
                        case 'R':
                            board[i, ctr] = new ChessPiece(Piece.Rook, Color.Black);
                            break;
                        case 'n':
                            board[i, ctr] = new ChessPiece(Piece.Knight, Color.White);
                            break;
                        case 'N':
                            board[i, ctr] = new ChessPiece(Piece.Knight, Color.Black);
                            break;
                    }
                }
            }

            return board;
        }

        /// <summary>
        /// Takes in a string and return true if it is an integer (number)
        /// Found this example here: https://stackoverflow.com/questions/894263/identify-if-a-string-is-a-number
        /// </summary>
        private bool IsNumeric(char c)
        {
            int n;
            bool isNumeric = int.TryParse(c.ToString(), out n);
            return isNumeric;
        }
    }
}
