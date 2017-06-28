using KUA.LOGIC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUA.LOGIC.Pieces
{
    public  class KingPiece : BasePiece
    {
        public KingPiece():base()
        {
            this.MoveDirections.Add(new Vector { X = -1, Y = 0 });
            this.MoveDirections.Add(new Vector { X = 1, Y = 0 });
            this.MoveDirections.Add(new Vector { X = 0, Y = -1 });
            this.MoveDirections.Add(new Vector { X = 0, Y = 1 });
            this.MoveDirections.Add(new Vector { X = -1, Y = -1 });
            this.MoveDirections.Add(new Vector { X = -1, Y = 1 });
            this.MoveDirections.Add(new Vector { X = 1, Y = -1 });
            this.MoveDirections.Add(new Vector { X = 1, Y = 1 });



        }
        //public override BasePiece KingIsInCheck(ChessBoard chessBoard)
        //{
        //    return null;
        //}
    }
}
