using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUA.LOGIC.Pieces;
using KUA.LOGIC.Helpers;

namespace KUA.LOGIC
{
    public class ChessBoardManager
    {
        private static  ChessBoardManager _instance;
        public List<ChessBoard> ListChessBoards { get; }

        private ChessBoardManager()
        {
            ListChessBoards = new List<ChessBoard>();

        }
        public static ChessBoardManager Instance {
            get {
                if (_instance == null) _instance = new ChessBoardManager();
                return _instance;


            }
                
                
        }

        public StringBuilder FindKingInCheck()
        {
            StringBuilder strOut = new StringBuilder();
            for (int i = 0; i < this.ListChessBoards.Count; i++)
            {
                string MessageResult = ChessBoardManager.Instance.ListChessBoards[i].getMessageKingInCheck();

                string strMessage = (!string.IsNullOrEmpty(MessageResult)) ? "Game #" + (i + 1).ToString() + ": " + MessageResult : string.Empty;


                if (!string.IsNullOrEmpty(strMessage)) strOut.AppendLine(strMessage);

            }

            return strOut;
        }

        public object position { get; private set; }

        /// <summary>
        /// This method need to read the 
        /// </summary>
        /// <param name="str"></param>
        public void LoadBoards(StringBuilder str)
        {
            string[] listLines = str.ToString().Split('\n');
            int intTableNum = listLines.Length / 8;
            //se barre la cantidad de tableros
            for (int itable = 0; itable < intTableNum; itable++)
            {
                //cada tablero tiene 8 filas y ocho columnas
                ChessBoard tempChessBoard = new ChessBoard();
                for (int i = 0; i < 8; i++)
                {
                    string strLinea = listLines[itable * 8 +i];

                    for (int j = 0; j < 8; j++)
                    {
                        char tempFicha = (strLinea.Length>8) ?strLinea[j]:'.';
                        BasePiece pieceBase = this.CreatePiace(tempFicha, i,j);
                        tempChessBoard.addPiece(pieceBase);


                    }

                }
                ListChessBoards.Add(tempChessBoard);


            }


        }

        private BasePiece CreatePiace(char tempFicha, int i, int j)
        {
            BasePiece basePiece = null;
            switch (tempFicha)
            {
                case 'b': basePiece = new KUA.LOGIC.Pieces.BishopPiece ();
                          basePiece.Position.X = i;
                          basePiece.Position.Y= j;
                          basePiece.IsWhite = false;
                    break;
                case 'B':
                    basePiece = new KUA.LOGIC.Pieces.BishopPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = true;
                    break;
                case 'p':
                    basePiece = new KUA.LOGIC.Pieces.PawnPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = false;
                    break;
                case 'P':
                    basePiece = new KUA.LOGIC.Pieces.PawnPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = true;
                    break;
                case 'r':
                    basePiece = new KUA.LOGIC.Pieces.RookPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = false;
                    break;
                case 'R':
                    basePiece = new KUA.LOGIC.Pieces.RookPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = true;
                    break;
                case 'q':
                    basePiece = new KUA.LOGIC.Pieces.QueenPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = false;
                    break;
                case 'Q':
                    basePiece = new KUA.LOGIC.Pieces.QueenPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = true;
                    break;
                case 'k':
                    basePiece = new KUA.LOGIC.Pieces.KingPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = false;
                    basePiece.IsKing = true;
                    break;
                case 'K':
                    basePiece = new KUA.LOGIC.Pieces.KingPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = true;
                    basePiece.IsKing = true;
                    break;
                case 'n':
                    basePiece = new KUA.LOGIC.Pieces.KnightPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = false;
                    break;
                case 'N':
                    basePiece = new KUA.LOGIC.Pieces.KnightPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = true;
                    break;
                default:
                    basePiece = new KUA.LOGIC.Pieces.EmptyPiece();
                    basePiece.Position.X = i;
                    basePiece.Position.Y = j;
                    basePiece.IsWhite = false;
                    basePiece.IsEmpty = true;
                    break;
            }
            return basePiece;

    }

        public void ClearBoards()
        {
            ListChessBoards.Clear();
        }
        

    }
}
