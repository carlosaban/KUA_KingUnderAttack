using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUA.LOGIC.Helpers;
using KUA.LOGIC.Pieces;

namespace KUA.LOGIC
{
    public class ChessBoard
    {
        private bool IsEmptyBoard = true;
        private List<Pieces.BasePiece> _chessboard { get; set; }

        public ChessBoard()
        {
            _chessboard = new List<BasePiece>();
        }
        public string getMessageKingInCheck()
        {
            if (this.IsEmptyBoard)
            {
                return string.Empty;
            }

            string strResult = string.Empty;
            BasePiece KingInCheck = null;

            foreach (var item in this._chessboard)
            {
                 KingInCheck= item.KingIsInCheck(this);
                if ( KingInCheck != null) break;
            }
            if (KingInCheck == null)
            {
                return "no king is in check";
            }

            strResult += (KingInCheck.IsWhite) ?"white":"black";
            strResult += " king is in check";
            return strResult;
        }

        internal void addPiece(BasePiece pieceBase)
        {
            this.IsEmptyBoard = (this.IsEmptyBoard && pieceBase.IsEmpty);
            _chessboard.Add(pieceBase);
        }

        internal BasePiece getPiece(Vector newPosition)
        {
            foreach (var item in this._chessboard)
            {
                if ((item.Position.X == newPosition.X) && (item.Position.Y == newPosition.Y)) return item;

            }
            return null;
        }
    }
}
