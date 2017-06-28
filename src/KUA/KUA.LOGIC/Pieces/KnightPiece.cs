using KUA.LOGIC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUA.LOGIC.Pieces
{
    public class KnightPiece : BasePiece
    {
        public KnightPiece() : base()
        {
            this.MoveDirections.Add(new Vector { X = 3, Y = -2 });
            this.MoveDirections.Add(new Vector { X = 3, Y = 2 });
            this.MoveDirections.Add(new Vector { X = 2, Y = -3 });
            this.MoveDirections.Add(new Vector { X = 2, Y = 3 });
            this.MoveDirections.Add(new Vector { X = -3, Y = 2 });
            this.MoveDirections.Add(new Vector { X = -3, Y = -2 });
            this.MoveDirections.Add(new Vector { X = -2, Y = 3 });
            this.MoveDirections.Add(new Vector { X = -2, Y = -3 });



        }
        //public override BasePiece KingIsInCheck(ChessBoard chessBoard)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
