using KUA.LOGIC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUA.LOGIC.Pieces
{
    public class PawnPiece : BasePiece
    {
        public PawnPiece() : base()
        {
            this.MoveDirections.Add(new Vector { X = 1, Y = -1 });
            this.MoveDirections.Add(new Vector { X = 1, Y = 1 });


        }
        /// <summary>
        /// I need to override because we need to move to one direction. It is a particular movement
        /// </summary>
        /// <param name="chessBoard"></param>
        /// <returns></returns>
        public override BasePiece KingIsInCheck(ChessBoard chessBoard)
        {
            foreach (var item in this.MoveDirections)
            {
                Vector newPosition = new Vector();
                newPosition.X = this.Position.X + item.X *(this.IsWhite?-1: 1) ;//I need to change the direccion if is white (uppercase)
                newPosition.Y = this.Position.Y + item.Y * (this.IsWhite ? -1 : 1);//I need to change the direccion if is white (uppercase)
                BasePiece piece = chessBoard.getPiece(newPosition);
                if (piece == null || piece.IsEmpty || !piece.IsKing || (this.IsWhite == piece.IsWhite)) continue;//try with the nex move
                return piece;
            }
            return null;
        }
    }
}
