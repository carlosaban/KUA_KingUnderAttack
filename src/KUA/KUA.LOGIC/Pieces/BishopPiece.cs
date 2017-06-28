using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUA.LOGIC.Helpers;

namespace KUA.LOGIC.Pieces
{
    public class BishopPiece : BasePiece
    {
        public BishopPiece() : base() {
            this.MoveDirections.Add(new Vector { X = -1, Y = -1 });
            this.MoveDirections.Add(new Vector { X = -1, Y = 1 });
            this.MoveDirections.Add(new Vector { X = 1, Y = -1 });
            this.MoveDirections.Add(new Vector { X = 1, Y = 1 });


        }

        public override BasePiece KingIsInCheck(ChessBoard chessBoard)
        {

            foreach (var item in this.MoveDirections)
            {
                Vector newPosition = new Vector();
                newPosition.X = this.Position.X + item.X;
                newPosition.Y = this.Position.Y + item.Y;
                BasePiece piece = chessBoard.getPiece(newPosition);
                if (piece!= null && piece.IsEmpty) piece = recursivaDirection(piece, item, chessBoard);

                if (piece == null || !piece.IsKing || (this.IsWhite == piece.IsWhite)) continue;//try with the nex move\

                
                return piece;
            }
            return null;

        }

        private BasePiece recursivaDirection(BasePiece piece, Vector Direction, ChessBoard chessBoard)
        {
            if (piece == null) return null;
            if (piece.IsKing && piece.IsWhite != this.IsWhite) return piece;
            if (!piece.IsEmpty) return null;

            Vector newPosition = new Vector();
            newPosition.X = piece.Position.X + Direction.X;
            newPosition.Y = piece.Position.Y + Direction.Y;
            BasePiece NextPiece = chessBoard.getPiece(newPosition);
            return recursivaDirection(NextPiece, Direction, chessBoard);
        }
    }
}
