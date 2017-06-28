using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KUA.LOGIC.Helpers;

namespace KUA.LOGIC.Pieces
{
    public abstract class BasePiece
    {

        public Vector Position { get; set; }
        public bool IsWhite { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsKing { get; set; }
        public List<Vector> MoveDirections { get; }

        public BasePiece() {
            this.MoveDirections = new List<Vector>();
            this.Position = new Vector();
            

        }
        public virtual BasePiece KingIsInCheck(ChessBoard chessBoard)
        {
            foreach (var item in this.MoveDirections)
            {
                Vector newPosition = new Vector();
                newPosition.X = this.Position.X + item.X;
                newPosition.Y = this.Position.Y + item.Y;
                BasePiece piece = chessBoard.getPiece(newPosition);
                if (piece == null || piece.IsEmpty || !piece.IsKing || (this.IsWhite == piece.IsWhite)) continue;//try with the nex move
                return piece;
            }
            return null;
        }
 
    }
}
